using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class AddHeaderAsyncFilter : Attribute, IAsyncResultFilter
    {
        private readonly string name;
        private readonly string value;

        public AddHeaderAsyncFilter(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // before 

            await next();

            // after
        }
    }
}