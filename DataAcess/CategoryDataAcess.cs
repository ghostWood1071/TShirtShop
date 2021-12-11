using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAcess.Interfaces;
using System.Data.SqlClient;
namespace DataAcess
{
    public class CategoryDataAcess : ICategoryAcessible
    {
        private IDataHelper helper;
        public CategoryDataAcess(IDataHelper helper)
        {
            this.helper = helper;
        }
        public List<CategoryResult> GetCategories()
        {
            helper.Open();
            SqlParameter[] parameters = new SqlParameter[]
            {
                helper.CreateParameter("@out_msg", "", System.Data.DbType.String, System.Data.ParameterDirection.Output),
                helper.CreateParameter("@out_err_code", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.Output),
                helper.CreateParameter("@out_err_line", -1, System.Data.DbType.Int32, System.Data.ParameterDirection.Output),
            };
            List<CategoryResult> results = helper.GetDatas<CategoryResult>("get_categories", parameters);
            helper.Close();
            return results;
        }
    }
}
