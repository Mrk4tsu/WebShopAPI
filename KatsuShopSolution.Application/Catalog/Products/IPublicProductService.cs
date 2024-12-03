using KatsuShopSolution.Application.Catalog.Products.DTO;
using KatsuShopSolution.Application.Catalog.Products.DTO.Public;
using KatsuShopSolution.Application.DTOs;

namespace KatsuShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PageResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
