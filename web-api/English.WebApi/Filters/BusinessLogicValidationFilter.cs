using English.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace English.WebApi
{
    public class BusinessLogicValidationFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is BusinessLogicException))
            {
                return;
            }

            if (context.Exception is EntityNotFoundException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
        }
    }
}
