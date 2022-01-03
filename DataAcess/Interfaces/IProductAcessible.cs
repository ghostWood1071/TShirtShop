using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataAcess.Interfaces
{
    public interface IProductAcessible
    {
        List<SaleResult> GetSales(int quantity);
        List<TrendingResult> GetTrendings(int quantity, string category_id);
        List<LatestResult> GetLatests(int quantity);
        List<ProductGet> GetAllProducts(string keyword);
        ProductDetailResult GetProductDetail(string product_id);
        List<ProductImage> GetProductImages(string product_id);
    }
}
