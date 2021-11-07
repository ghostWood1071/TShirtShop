using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Interfaces;
using System.Reflection;
using System.Data;

namespace DataAcess
{
    public class DataHelper : IDataHelper
    {
        private SqlConnection connection;
        private SqlCommand command;
        public SqlCommand Command { get { return command; } }
        public DataHelper(string conn)
        {
            connection = new SqlConnection(conn);
        }

        public void AddOuters(SqlParameter[] parameters)
        {
            Array.Resize<SqlParameter>(ref parameters, parameters.Length + 3);
            parameters[parameters.Length - 1] = new SqlParameter();
            parameters[parameters.Length - 1].ParameterName = "@out_msg";
            parameters[parameters.Length - 1].DbType = System.Data.DbType.String;
            parameters[parameters.Length - 1].Direction = System.Data.ParameterDirection.Output;

            parameters[parameters.Length - 2] = new SqlParameter();
            parameters[parameters.Length - 2].ParameterName = "@out_err_code";
            parameters[parameters.Length - 2].DbType = System.Data.DbType.Int32;
            parameters[parameters.Length - 2].Direction = System.Data.ParameterDirection.Output;

            parameters[parameters.Length - 3] = new SqlParameter();
            parameters[parameters.Length - 3].ParameterName = "@out_err_line";
            parameters[parameters.Length - 3].DbType = System.Data.DbType.Int32;
            parameters[parameters.Length - 3].Direction = System.Data.ParameterDirection.Output;
        }

        public int Close()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public SqlParameter CreateParameter(string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter()
            {
                ParameterName = name,
                Value = value,
                DbType = dbType,
                Direction = direction
            };
        }

        public void Excute(string procName, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            } catch(Exception e)
            {

            }
        }

        public List<T> GetDatas<T>(string procName, SqlParameter[] parameters)
        {
            try
            {
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                command.CommandText = procName;
                SqlDataReader reader = command.ExecuteReader();

                int length = parameters.Length-1;
                if ((int?)(parameters[length - 2].Value) > 0)
                    throw new Exception($"{parameters[length - 3].Value} in line {parameters[length].Value}");

                PropertyInfo[] properties = typeof(T).GetProperties();
                List<T> result = new List<T>();
                while (reader.Read())
                {
                    object newItem = Activator.CreateInstance(typeof(T));
                    for (int i = 0; i < properties.Length; i++) {
                        if(reader[properties[i].Name].GetType() == typeof(DBNull))
                            properties[i].SetValue(newItem, null);
                        else
                            properties[i].SetValue(newItem, reader[properties[i].Name]);
                    }
                    result.Add((T)newItem);
                }
                
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int Open()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                return 0;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        
    }
}
