using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderPost
    {
        public OrderPost()
        {

        }

        public OrderPost(string order_id, DateTime orderdate, double totlal_price, string shipping_address, string customer_id, string phone, string payment, int status, List<OrderDetail> list_details)
        {
            this.order_id = order_id;
            this.orderdate = orderdate;
            this.totlal_price = totlal_price;
            this.shipping_address = shipping_address;
            this.customer_id = customer_id;
            this.phone = phone;
            this.payment = payment;
            this.status = status;
            this.list_details = list_details;
        }

        public string order_id { get; set; }
        public DateTime orderdate { get; set; }
        public double totlal_price { get; set; }
        public string shipping_address { get; set; }
        public string customer_id { get; set; }
        public string phone { get; set; }
        public string payment { get; set; }
        public int status { get; set; }
        public List<OrderDetail> list_details { get; set; }
    }
}
