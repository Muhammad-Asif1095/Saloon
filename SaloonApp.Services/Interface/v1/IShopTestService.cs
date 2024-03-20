using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaloonApp.Services.Interface.v1
{
    public interface IShopTestService
    {
        Task<int> GetShopCount();
    }
}
