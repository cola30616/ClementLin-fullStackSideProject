using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    // primary context(.net 8 新功能) 省略ctor
    public class ProductRepository(StoreContext context) : IProductRepository
    {             
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
        }

        public async Task<IReadOnlyList<string>> GetBrandsAsync()
        {
            return await context.Products.Select(x => x.Brand).Distinct().ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort)
        {
            // 轉成IQueryable 型別

            // 產品品牌
            var  query = context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(brand))
                query = query.Where(x => x.Brand == brand);
            // 產品類型
            if (!string.IsNullOrWhiteSpace(type))
                query = query.Where(x => x.Type == type);
           // 價格查詢
            query = sort switch
            {
                "priceAsc" => query.OrderBy(x => x.Price),
                "priceDesc" => query.OrderByDescending(x => x.Price),
                _ => query.OrderBy(x => x.Name)
            };
                     
            // 在ToListAsync 在執行查詢 
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<string>> GetTypesAsync()
        {
            return await context.Products.Select(x => x.Type).Distinct().ToListAsync();
        }

        public bool ProductExists(int id)
        {
            return context.Products.Any(x=>x.Id == id);
        }

        public async Task<bool> SaveChangeAsync()
        {
            // SaveChangesAsync 會 return int ，可以用來檢查
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }
    }
}
