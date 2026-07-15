using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WinterStore.API.ExceptionHandling
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(
            exception,
            "An unhandled exception occurred during the processing of the request. MachineName: {MachineName}, TraceId: {TraceId}",
            Environment.MachineName,
            httpContext.TraceIdentifier);

            var statusCode = exception switch
            {
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                NotImplementedException => StatusCodes.Status501NotImplemented,
                _ => StatusCodes.Status500InternalServerError
            };

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = GetTitle(statusCode),
                Type = $"https://httpstatuses.com/{statusCode}",
                Detail = statusCode == 500
                    ? "An unexpected error occurred on the server. Our technical team has been notified."
                    : exception.Message,
                Instance = httpContext.Request.Path
            };

            problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);


            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/problem+json";

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            
            return true;
        }
        private static string GetTitle(int statusCode)
        {
            return statusCode switch
            {
                StatusCodes.Status401Unauthorized => "Unauthorized Access",
                StatusCodes.Status501NotImplemented => "Not Implemented",
                StatusCodes.Status500InternalServerError => "Server Error",
                _ => "An error occurred"
            };
        }
    }
}
