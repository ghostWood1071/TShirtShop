using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryResult
    {
        public Guid category_id { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
    }
}
