using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Json;
using Tasogarewa.Application.Common.Exceptions;

namespace CoursesWebAPI.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        
        public CustomExceptionHandlerMiddleware(RequestDelegate Next)=>
            this.next = Next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, exception);
            }
         
        }
        private Task HandleExceptionAsync(HttpContext context,Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;

            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            if(result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error=exception.Message});
            }
            return context.Response.WriteAsync(result);
        }
    }
}
