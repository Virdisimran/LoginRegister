using Application.CQRS.CustomerController.Command;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addCustomer = new AddCustomer
            {
                CustomerDTO = customer
            };

            var result = await mediator.Send(addCustomer);

            return Ok(result);
        }


      
    }
}
