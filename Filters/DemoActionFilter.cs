using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class DemoActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do work before action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do work after action is executed
        }
    }
}