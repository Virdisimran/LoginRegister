using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private ISender? _sender;
        protected ISender mediator => _sender ?? HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
