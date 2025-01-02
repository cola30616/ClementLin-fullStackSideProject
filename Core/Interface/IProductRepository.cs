using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    
    public interface IProductRepository
    {
        // Ireadonlylist 只是表達不會修改該類別 (也可以使用IEnumerable)
        Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort);
        Task<Product?> GetProductByIdAsync(int id);

        Task<IReadOnlyList<string>> GetBrandsAsync();
        Task<IReadOnlyList<string>> GetTypesAsync();

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        bool ProductExists(int id);

        Task<bool> SaveChangeAsync();
    }
}
