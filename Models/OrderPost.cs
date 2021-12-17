using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderPost
    {
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
