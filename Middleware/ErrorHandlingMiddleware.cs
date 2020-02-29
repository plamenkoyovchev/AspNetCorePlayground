using System;
using System.Threading.Tasks;
using AspNetCorePlayground.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AspNetCorePlayground.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IDateTimeService dateTimeService;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next, IDateTimeService dateTimeService, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.logger = logger;
            this.dateTimeService = dateTimeService;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //BEFORE next middleware execution ...

                await next(context);

                //AFTER next middleware execution ...
            }
            catch (Exception ex)
            {
                logger.LogError($"Error at {dateTimeService.GetDate()}: {ex.Message}");
            }
        }
    }
}