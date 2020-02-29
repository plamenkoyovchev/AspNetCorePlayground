using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class DemoActionFilter : IActionFilter
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