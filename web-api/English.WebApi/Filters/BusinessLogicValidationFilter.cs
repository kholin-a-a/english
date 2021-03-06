using English.BusinessLogic;
using Microsoft.AspNetCore.Mvc.Filters;

namespace English.WebApi
{
    public class BusinessLogicValidationFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is BusinessLogicException))
                return;

            // Bussiness logic exception!
            int b = 0;
        }
    }
}
