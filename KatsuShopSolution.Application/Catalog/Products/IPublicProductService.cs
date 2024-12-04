using KatsuShopSolution.ViewModels.Catalog.Products;
using KatsuShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatsuShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
