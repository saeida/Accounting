using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{

    public interface IQueryRepository<T> where T : class
    {
        //Write  Generic repository Here
        /// <summary>
        /// بازیابی یک شی با استفاده از شناسه آن
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// بازیابی تمامی شی‌های موجود در دیتابیس
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// بازیابی تمامی شی‌هایی که با معیار داده شده تطبیق دارند
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
