using Application.CQRS.RegistrationCQRS.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ApiController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp([FromBody] Registration registration)
        {
            var user = await mediator.Send(registration);
            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            return Ok(await mediator.Send(login));
        }
    }
}
