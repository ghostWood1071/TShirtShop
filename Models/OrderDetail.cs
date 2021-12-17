using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDetail
    {
		public string order_detail_id { get; set; }
		public double unit_price { get; set; }
		public string size_id { get; set; }
		public int quantity { get; set; }
		public double discount { get; set; }
	}
}
