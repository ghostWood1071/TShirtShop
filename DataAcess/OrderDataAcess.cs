using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAcess.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace DataAcess
{
    public class OrderDataAcess : IOrderAcessible
    {
        private IDataHelper helper;

        public OrderDataAcess(IDataHelper helper)
        {
            this.helper = helper;
        }
        public bool AddOrder(OrderPost order)
        {
            helper.Open();
            string listDetails = JsonSerializer.Serialize(order.list_details);
            SqlParameter[] parameters = new SqlParameter[]
            {
                helper.CreateParameter("@order_id", order.order_id, DbType.String),
                helper.CreateParameter("@orderdate", order.orderdate, DbType.DateTime),
                helper.CreateParameter("@totlal_price", order.totlal_price, DbType.Double),
                helper.CreateParameter("@shipping_address", order.shipping_address, DbType.String),
                helper.CreateParameter("@customer_id", order.customer_id, DbType.String),
                helper.CreateParameter("@phone", order.phone, DbType.String),
                helper.CreateParameter("@payment", order.payment, DbType.String),
                helper.CreateParameter("@status", order.status, DbType.Int32),
                helper.CreateParameter("@list_details", listDetails, DbType.String)
            };
            int result = helper.Excute("add_order", parameters);
            helper.Close();
            return result > 0;

        }
    }
}
