using Application.CQRS.ProductCQRS.Command;
using AutoMapper;
using Domain.DTOs;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductCQRS.Queries
{
    public class GetProducts:IRequest<List<Product>>
    {
        public int userId { get; set; }
    }
    public class GetProductsHandler : IRequestHandler<GetProducts, List<Product>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var userProducts = await _context.Products.Where(u => u.UserId == request.userId).ToListAsync();
            return userProducts;
        }


    }
}
