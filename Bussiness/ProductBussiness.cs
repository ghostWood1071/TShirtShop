using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Interfaces;
using DataAcess.Interfaces;
using Models;
using System.Text.Json;

namespace Bussiness
{
    public class ProductBussiness : IProductBuss
    {
        private IProductAcessible producAccess;
        public ProductBussiness(IProductAcessible productAcessible)
        {
            producAccess = productAcessible;
        }
        public List<Product> GetAllProducts(string keyword)
        {
            List<ProductGet> productGets =  producAccess.GetAllProducts(keyword);
            var query = from product in productGets
                        select new Product()
                        {
                            category_id = product.category_id,
                            category_name = product.category_name,
                            images = JsonSerializer.Deserialize<List<ProductImage>>(product.images==null?"[]":product.images),
                            isnew = product.isnew,
                            price_value = product.price_value,
                            product_id = product.product_id,
                            product_name = product.product_name,
                            quantity = product.quantity,
                            sold_quan = product.sold_quan
                        };

            List<Product> result = query.ToList();
            return result;
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

        public List<ProductImage> GetProductImages(string product_id)
        {
            return producAccess.GetProductImages(product_id);
        }
    }
}
