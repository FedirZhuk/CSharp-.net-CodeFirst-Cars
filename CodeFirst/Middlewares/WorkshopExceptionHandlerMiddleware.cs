using PrzykladowyKolok2.Exceptions;

namespace PrzykladowyKolok2.Middlewares;

public class WorkshopExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public WorkshopExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundInDatabase ex)
        {
            httpContext.Response.StatusCode = 404;
            httpContext.Response.ContentType = "text/plain";
            await httpContext.Response.WriteAsync(ex.Message);
        }
        catch (MoreThanOneOwner ex)
        {
            httpContext.Response.StatusCode = 404;
            httpContext.Response.ContentType = "text/plain";
            await httpContext.Response.WriteAsync(ex.Message);
        }
    }
}