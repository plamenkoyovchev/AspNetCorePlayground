using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class MyResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}