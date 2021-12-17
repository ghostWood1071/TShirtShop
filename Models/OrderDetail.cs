using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {
        }

        public OrderDetail(string order_detail_id, double unit_price, string size_id, int quantity, double discount)
        {
            this.order_detail_id = order_detail_id;
            this.unit_price = unit_price;
            this.size_id = size_id;
            this.quantity = quantity;
            this.discount = discount;
        }

        public string order_detail_id { get; set; }
		public double unit_price { get; set; }
		public string size_id { get; set; }
		public int quantity { get; set; }
		public double discount { get; set; }
	}
}
