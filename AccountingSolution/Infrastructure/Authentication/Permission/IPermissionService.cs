using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.Permission
{
    public interface IPermissionService
    {
        //List:گر نیاز دارید ترتیب عناصر را در داده‌ساختار حفظ کنید یا اجازه دهید تکرار عناصر مجاز باشد،
        //HashSet: اگر نیاز دارید به سرعت و با کارایی بالا عملیاتی مانند جستجو، افزودن و حذف اعضا را در مجموعه انجام دهید و عدم ترتیب مهم نیست واجازه تکرار ندارید
        Task<HashSet<String>> GetPermissionsAsync(Int64 userId);
    }
}
