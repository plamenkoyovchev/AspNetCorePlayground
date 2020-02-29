using System.Threading.Tasks;
using AspNetCorePlayground.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class AddHeaderAsyncFilterWithDI : IAsyncActionFilter
    {
        private readonly IDateTimeService dateTimeService;

        public AddHeaderAsyncFilterWithDI(IDateTimeService dateTimeService)
        {
            this.dateTimeService = dateTimeService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add("X-Time", $"{this.dateTimeService.GetDate()}");
            await next();
        }
    }
}