using KatsuShopSolution.Application.Catalog.Products.DTO;
using KatsuShopSolution.Application.Catalog.Products.DTO.Manage;
using KatsuShopSolution.Application.DTOs;
using KatsuShopSolution.Data.EF;
using KatsuShopSolution.Data.Entities;
using KatsuShopSolution.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatsuShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly KatsuShopDbContext _dbContext;
        public ManageProductService(KatsuShopDbContext context) 
        {
            _dbContext = context;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.UtcNow,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Details = request.Details,
                        SeoAlias = request.SeoAlias,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                }
            };

            _dbContext.Products.Add(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KatsuShopException($"Cannot find a product with Id: {product.Id}");
            }
            _dbContext.Products.Remove(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1.Select Join
            var query = from p in _dbContext.Products
                        join pt in _dbContext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _dbContext.ProductInCategories on p.Id equals pic.ProductId
                        join c in _dbContext.Categories on pic.CategoryId equals c.Id
                        select new
                        {
                            p, pt, pic
                        };
            //2.Filter
            if (!string.IsNullOrEmpty(request.KeyWord)) 
            {
                query = query.Where(x => x.pt.Name.Contains(request.KeyWord));
            }
            if (request.CategryIds.Count > 0)
            {
                query = query.Where(p => request.CategryIds.Contains(p.pic.CategoryId));
            }
            //3.Paging
            int total = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,                    
                    DateCreated = x.p.DateCreated,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //4.Select and project
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = total,
                Items = data
            };
            return pageResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _dbContext.Products.FindAsync(request.Id);
            var productTrans = await _dbContext.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product == null || productTrans == null)
            {
                throw new KatsuShopException($"Cannot find product with id: {request.Id}");
            }
            productTrans.Name = request.Name;
            productTrans.SeoAlias = request.SeoAlias;
            productTrans.SeoDescription = request.SeoDescription;
            productTrans.SeoTitle = request.SeoTitle;
            productTrans.Details = request.Details;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KatsuShopException($"Cannot find product with id: {productId}");
            }
            product.Price = newPrice;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KatsuShopException($"Cannot find product with id: {productId}");
            }
            product.Stock += addedQuantity;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
