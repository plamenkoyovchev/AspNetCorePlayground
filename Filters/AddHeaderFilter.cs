using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class AddHeaderFilter : Attribute, IResultFilter
    {
        private readonly string name;
        private readonly string value;

        public AddHeaderFilter(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}