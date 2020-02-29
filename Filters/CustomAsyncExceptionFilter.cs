using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class CustomAsyncExceptionFilter : Attribute, IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
        }
    }
}