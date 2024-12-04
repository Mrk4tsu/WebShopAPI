using Microsoft.AspNetCore.Http;

namespace KatsuShopSolution.ViewModels.Catalog.Products.Manage
{
    public class ProductCreateRequest
    {
        public string Name { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public IFormFile ThumnailImage { get; set; }
    }
}
