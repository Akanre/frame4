namespace Task1WebService.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestId = Guid.NewGuid().ToString();
            context.Items["RequestId"] = requestId;

            Console.WriteLine($"Request {requestId}: {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"Response {requestId}: {context.Response.StatusCode}");
        }
    }
}