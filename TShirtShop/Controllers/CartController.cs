using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Interfaces;
using Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Net.Http;
using System.IO;

namespace TShirtShop.Controllers
{
    public class CartController : Controller
    {
        private IOrderBuss orderBuss;
        public CartController(IOrderBuss orderBuss)
        {
            this.orderBuss = orderBuss;
        }
        //page
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<bool> CreateOrder()
        {
            //string rawOrder = await new StreamReader(Request.Body).ReadToEndAsync();
            //OrderPost order = await JsonSerializer.DeserializeAsync<OrderPost>(Request.Body);
            OrderPost order = await Request.ReadFromJsonAsync<OrderPost>();
            string rawUserData = HttpContext.Session.GetString("user");
            UserResult user = JsonSerializer.Deserialize<UserResult>(rawUserData);
            order.customer_id = user.user_id.ToString();
            order.orderdate = DateTime.Now;
            bool res = orderBuss.AddOrder(order);
            return res;
        }

        [HttpPost]
        public bool CreateOrderS(OrderPost order)
        {
            string rawUserData = HttpContext.Session.GetString("user");
            UserResult user = JsonSerializer.Deserialize<UserResult>(rawUserData);
            order.customer_id = user.user_id.ToString();
            order.orderdate = DateTime.Now;
            bool res = orderBuss.AddOrder(order);
            return res;
        }
    }
}
