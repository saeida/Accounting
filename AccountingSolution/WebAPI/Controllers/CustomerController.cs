using Application.Customer.Commands.CreateCustomer;
using Application.Customer.Queries.GetAllCustomer;
using Domain.Model.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// ایجاد یک مشتری جدید
        /// </summary>
        /// <param name="command">اطلاعات مشتری جدید</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// لیست مشتریان را برمیگرداند
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCustomerQuery")]
        public async Task<ActionResult<List<CustomerModel>>> GetAllCustomerQuery()
        {
            return await _mediator.Send(new GetAllCustomerQuery());
        }


    }
}
