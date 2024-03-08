using AutoMapper;
using Domain;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.CustomerController.Command
{
    public class AddCustomer:IRequest<CommonResponse>
    {
      public CustomerDTO? CustomerDTO { get; set; }
    }

    public class AddCustomerHandler : IRequestHandler<AddCustomer, CommonResponse>
    {
        public IApplicationDbContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public AddCustomerHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommonResponse> Handle(AddCustomer request, CancellationToken token)
        {
            try
            {
                var customerDTO = request.CustomerDTO;
                var customerEntity = _mapper.Map<Customers>(customerDTO);

                await _context.Customers.AddAsync(customerEntity);
                await _context.SaveChangesAsync();

                var productDTO = customerDTO.products;
                foreach(var product in productDTO)
                {
                    var productEntity = _mapper.Map<CustomerProducts>(product);
                    productEntity.CustomerId = customerEntity.Id; // Set the foreign key to the customer's ID

                    await _context.CustomersProducts.AddAsync(productEntity);
                    await _context.SaveChangesAsync();
                }
                

            }catch (Exception ex)
            {
                await _context.SaveChangesAsync();
                throw ex;
            }

            return new CommonResponse ("Added Successfully",  200 );

        }
    }
}
