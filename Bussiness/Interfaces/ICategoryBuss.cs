﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Bussiness.Interfaces
{
    public interface ICategoryBuss
    {
        List<CategoryResult> GetCategories();
    }
}
