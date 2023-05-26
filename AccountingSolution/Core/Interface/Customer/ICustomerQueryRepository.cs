using Domain.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Customer
{
    public interface ICustomerQueryRepository //: IQueryRepository<CustomerModel>
    {

     

        /// <summary>
        /// بازیابی یک شی با استفاده از شناسه آن
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public Task<CustomerModel> GetByIdAsync(Int64 id);
        /// <summary>
        /// بازیابی تمامی شی‌های موجود در دیتابیس
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerModel>> GetAllAsync();
       

    }
}
