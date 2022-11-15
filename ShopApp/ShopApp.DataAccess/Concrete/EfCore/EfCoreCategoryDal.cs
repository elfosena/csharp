using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EFcoreGenericRepository<Category, ShopContext>, ICategoryDal
    {

    }
}
