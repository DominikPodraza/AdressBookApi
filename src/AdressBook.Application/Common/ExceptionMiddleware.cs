using AdressBook.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AdressBook.Application.Common
{
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (HttpResponseException ex)
            {
                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsync(ex.Value.Description);
                logger.LogError(ex.Value.Description);
            }
        }
    }
}
