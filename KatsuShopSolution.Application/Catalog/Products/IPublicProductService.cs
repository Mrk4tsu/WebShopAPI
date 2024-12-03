using KatsuShopSolution.Application.Catalog.Products.DTO;
using KatsuShopSolution.Application.Catalog.Products.DTO.Public;
using KatsuShopSolution.Application.DTOs;
using System.Threading.Tasks;

namespace KatsuShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
