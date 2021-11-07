using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class AllProductResult
    {
		public List<AllProduct> products { get; set; }
		public int out_toal_row { get; set; }
	}
    public class AllProduct
    {
		string cate_id;
		public Int64 rownumber { get; set; }
		public Guid category_id { get; set; }
		public string category_name { get { return cate_id; } set { cate_id = value.ToString(); } }
		public string product_id { get; set; }
		public string product_name { get; set; }
		public double price_value { get; set; }
		public string images { get; set; }
		public int sold_quan { get; set; }
		public int isnew { get; set; }
		public int quantity { get; set; }

	}
}
