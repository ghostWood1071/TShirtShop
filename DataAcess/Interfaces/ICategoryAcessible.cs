using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataAcess.Interfaces
{
    public interface ICategoryAcessible
    {
        List<CategoryResult> GetCategories();
    }
}
