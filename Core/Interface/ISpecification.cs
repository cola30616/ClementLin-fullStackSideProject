using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ISpecification<T>
    {
        // 定義where (多數LinQ 都是這個，所以叫他criteria)
        Expression<Func<T, bool>>? Criteria { get; }

        Expression<Func<T, object>>? OrderBy { get; }

        Expression<Func<T, object>>? OrderByDescending { get; }

        bool IsDistinct { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled {  get; }

        IQueryable<T> ApplyCriteria(IQueryable<T> query);
    }

    // 新增projection 版本
    public interface ISpecification<T, TResult> : ISpecification<T>
    {
        Expression<Func<T, TResult>>? Select { get; }
    }
}
