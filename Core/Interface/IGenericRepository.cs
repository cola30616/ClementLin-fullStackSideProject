using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    // 使用generic repository 的方式設計
    public interface IGenericRepository<T> where T : BaseEntity // 限制T只能是BaseEntity 或是 其派生類別
    {
        Task<T?> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T?> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        // projection(overloading) 當有資料篩選需求時，使用投影方法（TResult）會更具效率 ; <T, TResult> 通常用於定義「輸入類型 T」和「輸出類型 TResult」的映射邏輯。
        Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> spec);
        Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        Task<bool> SaveAllAsync();

        bool Exists(int id);

        Task<int> CountAsync(ISpecification<T> spec);


    }
}
