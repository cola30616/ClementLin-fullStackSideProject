using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICartService
    {
        Task<ShoppingCart?> GetCartAsync(string key);

        Task<ShoppingCart?> SetCartAsync(ShoppingCart carts);

        Task<bool> DeleteCartAsync(string key);
    }
}
