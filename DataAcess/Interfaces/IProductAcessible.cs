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
        AllProductResult GetAllProducts(string keyword, int index, int pagesize);
        ProductDetailResult GetProductDetail(string product_id); 
    }
}
