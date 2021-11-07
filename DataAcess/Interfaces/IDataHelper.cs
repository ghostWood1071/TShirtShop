using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DataAcess.Interfaces
{
    public interface IDataHelper
    {
        SqlCommand Command { get; }
        int Open();
        int Close();
        List<T> GetDatas<T>(string procName, SqlParameter[] parameters);
        void Excute(string procName, SqlParameter[] parameters);
        void AddOuters(SqlParameter[] parameters);
        SqlParameter CreateParameter(string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input);
    }
}
