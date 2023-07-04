

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Context;
using System.Net;

using WebAPI.Model;

namespace WebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
     

        public ExceptionMiddleware(RequestDelegate next)
        {
         
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }


            if (httpContext.Response.StatusCode == (int)HttpStatusCode.OK && httpContext.Items.ContainsKey("data"))
            {
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new MessageResult<object>
                {
                    Data = httpContext.Items["data"],
                    Message = "عملیات با موفیت انجام شد", //httpContext.Items["message"].ToString()
                    StatusCode = (int)HttpStatusCode.OK
                }));
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                MessageResult<object> returnResult = null;
            LogContext.PushProperty("UserId", "123");
            Log.Error(exception,"Status Code Is   {@StatusCode} - Error Message Is {@Message} ", context.Response.StatusCode, exception.Message);

            returnResult = new MessageResult<object>
            {
                Data = null,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                StatusCode = (int)HttpStatusCode.InternalServerError
        };
          
           // }
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonString = JsonConvert.SerializeObject(returnResult, jsonSerializerSettings);
            await context.Response.WriteAsync(jsonString);




        }
    }
}
