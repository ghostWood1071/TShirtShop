using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserResult
    {
        public Guid user_id { get; set; }

        public string user_account { get; set; }

        public string user_name { get; set; }
        
        public DateTime birth_day { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public string password { get; set; }

        public int role { get; set; }

    }
}
