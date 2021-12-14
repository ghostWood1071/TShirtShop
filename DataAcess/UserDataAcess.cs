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
    public class UserDataAcess : IAccountAcessible
    {
        private IDataHelper helper;
        
        public UserDataAcess(IDataHelper helper)
        {
            this.helper = helper;
        }
        public UserResult GetUser(string account, string password)
        {
            helper.Open();
            SqlParameter[] parameters = new SqlParameter[] {
                helper.CreateParameter("@account", account, DbType.String),
                helper.CreateParameter("@password", password, DbType.String),
                helper.CreateParameter("@out_msg", "", DbType.String, ParameterDirection.Output),
                helper.CreateParameter("@out_err_code", 0, DbType.Int32, ParameterDirection.Output),
                helper.CreateParameter("@out_err_line", -1, DbType.Int32, ParameterDirection.Output)
            };
            List<UserResult> users = helper.GetDatas<UserResult>("check_account", parameters);
            helper.Close();
            if (users == null)
                return null;
            return users.FirstOrDefault();
        }
    }
}
