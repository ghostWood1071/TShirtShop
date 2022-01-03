using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Interfaces;
using Models;
namespace TShirtShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductBuss productBuss;
        private ICategoryBuss categoryBuss;
        public ProductController(IProductBuss productBuss, ICategoryBuss categoryBuss)
        {
            this.productBuss = productBuss;
            this.categoryBuss = categoryBuss;
        }

        //page
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }

        //ultilities
        public IEnumerable<TrendingResult> GetTrendings(int quantity, string category_id)
        {
            return productBuss.GetTrendings(quantity, category_id);
        }

        public IEnumerable<SaleResult> GetSales(int quantity)
        {
            return productBuss.GetSales(quantity);
        }

        public IEnumerable<LatestResult> GetLatests(int quantity)
        {
            return productBuss.GetLatests(quantity);
        }

        public List<Product> GetAllProduct(string keyword)
        {
            return productBuss.GetAllProducts(keyword);
        }

        public ProductDetailResult GetProductDetail(string product_id)
        {
            return productBuss.GetProductDetail(product_id);
        }

        public List<CategoryResult> GetCategories()
        {
            return categoryBuss.GetCategories();
        }

        public List<ProductImage> GetProductImages(string product_id)
        {
            return productBuss.GetProductImages(product_id);
        }

    }
}
