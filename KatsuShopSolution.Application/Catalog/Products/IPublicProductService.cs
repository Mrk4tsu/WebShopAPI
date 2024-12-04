using KatsuShopSolution.ViewModels.Catalog.Products;
using KatsuShopSolution.ViewModels.Catalog.Products.Public;
using KatsuShopSolution.ViewModels.Common;
using System.Threading.Tasks;

namespace KatsuShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
