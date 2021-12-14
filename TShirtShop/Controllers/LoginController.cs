using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Bussiness.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
namespace TShirtShop.Controllers
{
    public class LoginController : Controller
    {
        private IUserBussiness userBuss;
        public LoginController(IUserBussiness userBuss)
        {
            this.userBuss = userBuss;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public UserInfoRessult CheckAccount(string account, string password)
        {
            if (account == null || password == null)
                return null;
            UserResult result = userBuss.GetUser(account, password);
            if(result != null)
            {
                string value =  JsonSerializer.Serialize(result, typeof(UserResult));
                HttpContext.Session.SetString("user", value);
                return new UserInfoRessult {
                    account = result.user_account,
                    address = result.address,
                    full_name = result.user_name
                };
            }
            return null;
        }

        public bool Authenticate()
        {
            try
            {
                string cookieData = HttpContext.Session.GetString("user");
                UserResult user = JsonSerializer.Deserialize<UserResult>(cookieData);
                if (user == null)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
