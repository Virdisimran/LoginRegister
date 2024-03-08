using Application;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace EHRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        public IDapperContext _dapper;

        public DapperController(IDapperContext dapper)
        {
            _dapper = dapper;
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                string query = "SELECT * from Products";
                var parameters = new { };
                var products = await _dapper.GetAll(query,parameters);
                return Ok(products);    

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetProductById (int id)
        {
            try
            {
                string query = "Select * from products where id = @id";
                var parameter = new { id };
                var product = await _dapper.GetAll(query,parameter);
                return Ok(product);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> AddProducts([FromBody] productD product)
        {
            try
            {
                string query = "Insert into Products(Productname,ProductCode,Category,Brand,SellingPrice,PurchasePrice,SellingDate,UserId) values(@Productname,@ProductCode,@Category,@Brand,@SellingPrice,@PurchasePrice,@SellingDate,@UserId)";
                var parameters = new productD
                {
                    ProductName = product.ProductName,
                    ProductCode = product.ProductCode,
                    Category = product.Category,
                    Brand = product.Brand,
                    SellingPrice = product.SellingPrice,
                    PurchasePrice = product.PurchasePrice,
                    SellingDate = product.SellingDate,
                    UserId = product.UserId,
                };
                
                var products = _dapper.AddProduct(query,parameters);
                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("[action]")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                string query = "delete from products where id = @id";
                var parameter = new { id };
                var product = await _dapper.DeleteProduct(query, parameter);
                return Ok(product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]

        public async Task<IActionResult> UpdateProduct([FromBody] productD product,int id)
        {
            try
            {
                string query = @"UPDATE Products 
                 SET Productname = @ProductName,
                     ProductCode = @ProductCode,
                     Category = @Category,
                     Brand = @Brand,
                     SellingPrice = @SellingPrice,
                     PurchasePrice = @PurchasePrice,
                     SellingDate = @SellingDate,
                     UserId = @UserId
                 WHERE Id = @Id";

                var parameter = new productD
                {
                    Id = id,
                    ProductName = product.ProductName,
                    ProductCode = product.ProductCode,
                    Category = product.Category,
                    Brand = product.Brand,
                    SellingPrice = product.SellingPrice,
                    PurchasePrice = product.PurchasePrice,
                    SellingDate = product.SellingDate,
                    UserId = product.UserId
                };
                await _dapper.UpdateProduct(query, parameter);
                return Ok("Updated Successfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
