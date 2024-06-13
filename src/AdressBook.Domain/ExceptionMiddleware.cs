using AdressBook.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AdressBook.Domain;

public class ExceptionMiddleware (ILogger<ExceptionMiddleware> logger, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (HttpResponseException ex)
        {

            context.Response.StatusCode = (int) ex.StatusCode;
            logger.LogError(ex.Value.Description);
        }
    }
}