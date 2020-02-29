using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCorePlayground.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
        }
    }
}