using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductGet
    {
		public Guid category_id { get; set; }
		public string category_name { get; set; }
		public string product_id { get; set; }
		public string product_name { get; set; }
		public double price_value { get; set; }
		public string images { get; set; }
		public int sold_quan { get; set; }
		public int isnew { get; set; }
		public int quantity { get; set; }
	}
}
