using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderDal : EFcoreGenericRepository<Order, ShopContext>, IOrderDal
    {
    }
}
