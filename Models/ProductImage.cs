using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductImage
    {
        public ProductImage()
        {
        }

        public ProductImage(string image_url)
        {
            this.image_url = image_url;
        }

        public string image_url { get; set; }
    }
}
