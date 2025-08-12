using System.Net;
using System.Text.Json;

namespace BSEB_API2026.Middleware
{
    public class ErrorHandlerMiddleware(RequestDelegate _next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = error switch
                {
                    ApplicationException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                // _logger.WriteError($"Exception: {JsonSerializer.Serialize(new { message = error?.Message })} \n StackTrace: {error?.StackTrace}");

                await response.WriteAsync(JsonSerializer.Serialize(new { message = error?.Message }));
            }
        }
    }
}
