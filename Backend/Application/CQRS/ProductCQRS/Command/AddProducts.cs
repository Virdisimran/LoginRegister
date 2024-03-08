using AutoMapper;
using Domain;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductCQRS.Command
{
    public class AddProducts : IRequest<Response>
    {
        public ProductDTO? ProductDTO { get; set; }
    }
    public class AddProductsHandler : IRequestHandler<AddProducts, Response>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddProductsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(AddProducts request, CancellationToken cancellationToken)
        {
            // Check if a product with the given userId already exists in the database
            var existingProduct = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.ProductDTO.UserId);

            if (existingProduct != null)
            {
                var pc = RandomString() + "_" + request.ProductDTO.ProductName;

                // Create a new Product entity
                var newProduct = new Product
                {
                    UserId = request.ProductDTO.UserId,
                    ProductName = request.ProductDTO.ProductName,
                    ProductCode = pc,
                    PurchasePrice = request.ProductDTO.PurchasePrice,
                    SellingDate = request.ProductDTO.SellingDate,
                    SellingPrice = request.ProductDTO.SellingPrice,
                    Category = request.ProductDTO.Category,
                    Brand = request.ProductDTO.Brand
                };

                // Add the new product to the Products DbSet
                _context.Products.Add(newProduct);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return new Response("Added Successfully", true, 200);
            }
            else
            {
                return new Response("User does not exist", false, 400);
            }
        }




        public string RandomString()
        {
            var random = new Random();
            string str = "PWHSU473ANIcmshui42793";
            string ran = string.Empty;
            int size = 6;

            for (int i = 0; i < size; i++)
            {
                int x = random.Next(6);
                ran = ran + str[x];
            }

            return ran;
        }
    }
}


