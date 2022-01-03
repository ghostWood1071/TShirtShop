using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Interfaces;
using Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace TShirtShop.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
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
        public bool CheckAccount(string account, string password)
        {
            UserResult user = userBuss.GetUser(account, password); // phương thức lấy về thông tin người dùng
            if (user != null)
            {

                //lưu vào cookie  
                var identity = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, account)}, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return true;
            }
            return false;
        }
    }
}
