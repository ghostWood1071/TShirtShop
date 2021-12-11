using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Interfaces;
using DataAcess.Interfaces;
using Models;

namespace Bussiness
{
    public class ProductBussiness : IProductBuss
    {
        private IProductAcessible producAccess;
        public ProductBussiness(IProductAcessible productAcessible)
        {
            producAccess = productAcessible;
        }
        public AllProductResult GetAllProducts(string keyword)
        {
            return producAccess.GetAllProducts(keyword);
        }

        public List<LatestResult> GetLatests(int quantity)
        {
            return producAccess.GetLatests(quantity);
        }

        public ProductDetailResult GetProductDetail(string product_id)
        {
            return producAccess.GetProductDetail(product_id);
        }

        public List<SaleResult> GetSales(int quantity)
        {
            return producAccess.GetSales(quantity);
        }

        public List<TrendingResult> GetTrendings(int quantity, string category_id)
        {
            return producAccess.GetTrendings(quantity, category_id);
        }
    }
}
