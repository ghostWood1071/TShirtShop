using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Bussiness.Interfaces;
using DataAcess.Interfaces;
namespace Bussiness
{
    public class CategoryBussiness : ICategoryBuss
    {
        private ICategoryAcessible category;
        public CategoryBussiness(ICategoryAcessible category)
        {
            this.category = category;
        }
        public List<CategoryResult> GetCategories()
        {
            return category.GetCategories();
        }
    }
}
