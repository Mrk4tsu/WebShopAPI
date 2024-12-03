﻿using KatsuShopSolution.Application.Catalog.Products.DTO;
using KatsuShopSolution.Application.Catalog.Products.DTO.Public;
using KatsuShopSolution.Application.DTOs;
using KatsuShopSolution.Data.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KatsuShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly KatsuShopDbContext _dbContext;
        public PublicProductService(KatsuShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            //1.Select Join
            var query = from p in _dbContext.Products
                        join pt in _dbContext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _dbContext.ProductInCategories on p.Id equals pic.ProductId
                        join c in _dbContext.Categories on pic.CategoryId equals c.Id
                        select new
                        {
                            p,
                            pt,
                            pic
                        };
            //2.Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
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
    }
}
