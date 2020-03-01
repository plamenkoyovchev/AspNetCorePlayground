using AspNetCorePlayground.ModelBinders.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCorePlayground.ModelBinders.Providers
{
    public class YearModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata?.Name.ToLower() == "year" &&
                context.Metadata?.ModelType == typeof(int))
            {
                return new YearModelBinder();
            }

            return null;
        }
    }
}