using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using System.Net;

namespace MakFood.Kitchen.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (ValidationFailedDomainException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(exception.Message);
            }

            catch (ForbbidenDomainException exception)
            {
                context.Response.StatusCode = (int)(HttpStatusCode.Forbidden);
                await context.Response.WriteAsync(exception.Message);
            }

            catch (Exception exception)
            {
                context.Response.StatusCode = (int)((HttpStatusCode)HttpStatusCode.InternalServerError);
                await context.Response.WriteAsync("An unexpected server error occurred.");
            }
        }
    }
}
