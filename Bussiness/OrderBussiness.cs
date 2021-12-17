using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Interfaces;
using Models;
using Bussiness.Interfaces;
using System.Text.Json;
namespace Bussiness
{
    public class OrderBussiness : IOrderBuss
    {
        private IOrderAcessible orderAcess;
        public OrderBussiness(IOrderAcessible orderAcess)
        {
            this.orderAcess = orderAcess;
        }
        public bool AddOrder(OrderPost order)
        {
            order.order_id = Guid.NewGuid().ToString();
            for(int i = 0; i<order.list_details.Count; i++)
               order.list_details[i].order_detail_id = Guid.NewGuid().ToString();
            return orderAcess.AddOrder(order);
        }
    }
}
