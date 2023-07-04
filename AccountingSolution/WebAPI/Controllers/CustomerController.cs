using Application.Customer.Commands.CreateCustomer;
using Application.Customer.Queries.GetAllCustomer;
using Domain.Model.Customer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Serilog;
using Serilog.Events;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using WebAPI.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult<List<CustomerModel>>> GetAllCustomerQuery()
        {
            //Log.Information("Getting the Test running...");
            //var Count = 10;
            //Log.Error("Customer Number Is  {@Count} retrieved from DB", Count);
            //Log.ForContext("UserId", "101").Information("Log message");
            // var culture = HttpContext.Request.Headers["Accept-Language"].ToString();

            // Set the current culture of the thread
            /// CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            // CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(culture);

         

            HttpContext.Items["data"] = await _mediator.Send(new GetAllCustomerQuery());

            return Ok();


            #region Other Sample

            // Log.Error(exception, "An error occurred for user {UserName} ({UserId}) from IP address {UserIp}", userName, userId, userIp);

            //    SELECT

            //    Properties.value('(/properties/property[@key="contact"]/structure[@type="Contact"]/property[@key="ContactId"])[1]', 'nvarchar(max)') AS ContactId,
            //    Properties.value('(/properties/property[@key="contact"]/structure[@type="Contact"]/property[@key="FirstName"])[1]', 'nvarchar(50)') AS FirstName,
            //    Properties.value('(/properties/property[@key="contact"]/structure[@type="Contact"]/property[@key="Surname"])[1]', 'nvarchar(100)') AS Surname,
            //    Properties.value('(/properties/property[@key="cacheKey"])[1]', 'nvarchar(100)') AS CacheKey,
            //     *
            //    FROM Log
            //    WHERE MessageTemplate = 'Contact {@contact} added to cache with key {@cacheKey}'
            //    AND Properties.value('(/properties/property[@key="contact"]/structure[@type="Contact"]/property[@key="ContactId"])[1]', 'nvarchar(max)') = 'f7d10f53-4c11-44f4-8dce-d0e0e22cb6ab'



            //try
            //{           
            //    // دستوراتی برای دریافت داده
            //    return Ok(  await _mediator.Send(new GetAllCustomerQuery()));
            //}
            //catch (Exception ex)
            //{
            //    var error = new MessageResult<object>
            //    {
            //        Data = null,
            //        Message = "خطایی در هنگام اجرای عملیات رخ داده است.",
            //        StackTrace=ex.StackTrace,
            //        StatusCode="500"
            //    };

            //    return new ObjectResult(error)
            //    {
            //        StatusCode = 500
            //    };
            //}


            #endregion

        }


    }
}
