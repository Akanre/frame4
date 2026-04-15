namespace Task1WebService.Middleware
{
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;

        public TimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            await _next(context);

            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
        }
    }
}   