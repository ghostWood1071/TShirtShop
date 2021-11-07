using System;
using Models;
using DataAcess;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataHelper dataHelper = new DataHelper("Server = DESKTOP-J65EBGL; Initial Catalog = mvc_ecomerce_project3; user = sa; password =111");
            dataHelper.Open();
            ProductDataAcess dataAcess = new ProductDataAcess(dataHelper);
            // List<TrendingResult> result = dataAcess.GetTrendings(1, "c868f1bc-102d-4bed-9a41-686a9d50aaaf");
            //List<SaleResult> result = dataAcess.GetSales(2);
            ProductDetailResult result = dataAcess.GetProductDetail("SP00000001");
            Console.WriteLine(result.price_value);
        }
    }
}
