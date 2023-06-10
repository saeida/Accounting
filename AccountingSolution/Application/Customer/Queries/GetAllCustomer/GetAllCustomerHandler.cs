
using Domain.Interface.Customer;
using Domain.Model.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Application.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerModel>>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;    
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAllCustomerHandler(ICustomerQueryRepository customerQueryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _customerQueryRepository = customerQueryRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<List<CustomerModel>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {

        

            ////// Get the current culture from the request headers
            //var culture = _httpContextAccessor.HttpContext.Request.Headers["Accept-Language"].ToString();
            //culture = culture.Split(",")[0];
            ////// Set the current culture of the thread
            //CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);

         

            var resourceManager = new ResourceManager("Application.Resources.Message", Assembly.GetExecutingAssembly());
            var message = resourceManager.GetString("CustomerNotExist", CultureInfo.CurrentCulture);
         
            throw new Exception(message);

            return (List<CustomerModel>)await _customerQueryRepository.GetAllAsync();
        }
    }
}
