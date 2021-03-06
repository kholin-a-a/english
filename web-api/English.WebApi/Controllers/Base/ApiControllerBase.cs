using Microsoft.AspNetCore.Mvc;

namespace English.WebApi.Controllers
{
    [ApiController]
    [Route("{controller}")]
    [TypeFilter(typeof(BusinessLogicValidationFilter))]
    public class ApiControllerBase : ControllerBase
    {
    }
}
