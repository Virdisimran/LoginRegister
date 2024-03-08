using Application.CQRS.ProductCQRS;
using Application.CQRS.ProductCQRS.Command;
using Application.CQRS.ProductCQRS.Queries;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        [HttpPost("[action]")]

        public async Task<IActionResult> AddProducts([FromBody] ProductDTO productDTO)
        {
            var addProductsCommand = new AddProducts
            {
                ProductDTO = productDTO
            };

            var user = await mediator.Send(addProductsCommand);
            return Ok(user);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProducts(int id)
        {
            return Ok(await mediator.Send(new GetProducts { userId = id }));
        }

    }
}
