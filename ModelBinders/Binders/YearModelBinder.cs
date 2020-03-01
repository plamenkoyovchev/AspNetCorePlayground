using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCorePlayground.ModelBinders.Binders
{
    public class YearModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var dateFromRequest = bindingContext.ValueProvider.GetValue("date").FirstOrDefault();
            if (string.IsNullOrWhiteSpace(dateFromRequest))
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Success(dateFromRequest);
            }

            return Task.CompletedTask;
        }
    }
}