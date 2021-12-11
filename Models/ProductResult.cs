using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductResult
    {

        public string product_id { get; set; }
        public string product_name { get; set; }
        public double price_value { get; set; }
        public double discount { get; set; }
        public int quantity { get; set; }
        public int isnew { get; set; }
        public string img { get; set; }
    }
}
