namespace PrzykladowyKolok2.Middlewares;

public static class WorkshopMiddlewareExtentions
{
    public static IApplicationBuilder UseWorkshopErrorHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<WorkshopExceptionHandlerMiddleware>();
    }
}