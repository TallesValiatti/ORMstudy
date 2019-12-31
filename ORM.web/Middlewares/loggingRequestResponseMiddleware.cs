using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ORM.web.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class loggingRequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<loggingRequestResponseMiddleware> _log;

        public loggingRequestResponseMiddleware(RequestDelegate next, ILogger<loggingRequestResponseMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _log.LogInformation(await FormatRequest(httpContext.Request));
            await _next(httpContext);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            
            request.Body.Seek(0, SeekOrigin.Begin);
            // request.Body = body;

            var strBody = Encoding.UTF8.GetString(buffer).ToString();

            return $"{Environment.NewLine}****** request *******{Environment.NewLine}" +
                   $"PATH: {request.Path} \n" +
                   $"BODY: {strBody}";
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class loggingRequestResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseloggingRequestResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<loggingRequestResponseMiddleware>();
        }
    }
}
