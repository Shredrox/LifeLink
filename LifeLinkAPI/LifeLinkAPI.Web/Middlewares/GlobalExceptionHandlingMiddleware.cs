using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next, 
        ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred.");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problemDetails = new ProblemDetails()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Server Error",
                Detail = "An internal server error has occurred"
            };
            
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}