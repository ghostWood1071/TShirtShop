using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Interfaces;
using Models;
using System.Data.SqlClient;
using System.Data;
namespace DataAcess
{
    public class ProductDataAcess : IProductAcessible
    {
        private IDataHelper helper;
        public ProductDataAcess(IDataHelper helper)
        {
            this.helper = helper;
        }
        public AllProductResult GetAllProducts(string keyword, int index, int pagesize)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                helper.CreateParameter("@keyword", keyword, DbType.String),
                helper.CreateParameter("@index", index, DbType.Int32),
                helper.CreateParameter("@page_size", pagesize, DbType.Int32),
                helper.CreateParameter("@out_toal_row", 0, DbType.Int64, ParameterDirection.Output),
                helper.CreateParameter("@out_msg", "", DbType.String, ParameterDirection.Output),
                helper.CreateParameter("@out_err_code", 0, DbType.Int32, ParameterDirection.Output),
                helper.CreateParameter("@out_err_line", -1, DbType.Int32, ParameterDirection.Output)
            };
            //helper.AddOuters(sqlParameters);
            AllProductResult result = new AllProductResult();
            result.products = helper.GetDatas<AllProduct>("get_products", sqlParameters);
            result.out_toal_row = (int)helper.Command.Parameters["@out_toal_row"].Value;
            return result;
        }
        public List<LatestResult> GetLatests(int quantity)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                helper.CreateParameter("@quantity",quantity,DbType.Int32),
                helper.CreateParameter("@out_msg", "", DbType.String, ParameterDirection.Output),
                helper.CreateParameter("@out_err_code", 0, DbType.Int32, ParameterDirection.Output),
                helper.CreateParameter("@out_err_line", -1, DbType.Int32, ParameterDirection.Output)
            };
            helper.AddOuters(sqlParameters);
            List<LatestResult> latests = helper.GetDatas<LatestResult>("get_latest", sqlParameters);
            return latests;
        }
        public ProductDetailResult GetProductDetail(string product_id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                helper.CreateParameter("@product_id",product_id,DbType.String),
                helper.CreateParameter("@out_msg", "", DbType.String, ParameterDirection.Output),
                helper.CreateParameter("@out_err_code", 0, DbType.Int32, ParameterDirection.Output),
                helper.CreateParameter("@out_err_line", -1, DbType.Int32, ParameterDirection.Output)
            };
            helper.AddOuters(sqlParameters);
            List<ProductDetailResult> latests = helper.GetDatas<ProductDetailResult>("get_product", sqlParameters);
            return latests.First();
        }
        public List<SaleResult> GetSales(int quantity)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                helper.CreateParameter("@quantity",quantity,DbType.Int32),
                helper.CreateParameter("@out_msg", "", DbType.String, ParameterDirection.Output),
                helper.CreateParameter("@out_err_code", 0, DbType.Int32, ParameterDirection.Output),
                helper.CreateParameter("@out_err_line", -1, DbType.Int32, ParameterDirection.Output)
            };
            helper.AddOuters(sqlParameters);
            List<SaleResult> latests = helper.GetDatas<SaleResult>("get_sale", sqlParameters);
            return latests;
        }
        public List<TrendingResult> GetTrendings(int quantity, string category_id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                helper.CreateParameter("@category_id", Guid.Parse(category_id), DbType.Guid),
                helper.CreateParameter("@quantity", quantity, DbType.Int32),
                helper.CreateParameter("@out_msg", "", DbType.String, ParameterDirection.Output),
                helper.CreateParameter("@out_err_code", 0, DbType.Int32, ParameterDirection.Output),
                helper.CreateParameter("@out_err_line", -1, DbType.Int32, ParameterDirection.Output)
            };
            List<TrendingResult> latests = helper.GetDatas<TrendingResult>("get_trending", sqlParameters);
            return latests;
        }
    }
}
