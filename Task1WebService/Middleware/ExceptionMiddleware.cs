using Task1WebService.Models;

namespace Task1WebService.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                var requestId = context.Items["RequestId"]?.ToString();

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var error = new ErrorResponse
                {
                    Code = "internal_error",
                    Message = ex.Message,
                    RequestId = requestId
                };

                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}