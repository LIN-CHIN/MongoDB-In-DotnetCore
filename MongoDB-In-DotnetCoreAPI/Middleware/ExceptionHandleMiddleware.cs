using Common;
using Microsoft.AspNetCore.Http;
using Model.ResultModel;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MongoDB_In_DotnetCoreAPI.Middleware
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex) 
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            ReturnModel result = new ReturnModel
            {
                Code = ResponseCode.SystemError,
                Detail = ex.ToString(),
                Content = new 
                {
                    ExceptionMassage = ex.Message,
                    InnerException = ex.InnerException
                }
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(result.GetResult()));
        }
    }
}
