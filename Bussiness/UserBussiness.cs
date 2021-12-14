using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Interfaces;
using Models;
using DataAcess.Interfaces;
namespace Bussiness
{
    public class UserBussiness : IUserBussiness
    {
        private IAccountAcessible accountAcess;

        public UserBussiness(IAccountAcessible accountAcess)
        {
            this.accountAcess = accountAcess;
        }
        public UserResult GetUser(string account, string password)
        {
            password = CreateMD5(password);
            return accountAcess.GetUser(account, password);
        }

        public string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
