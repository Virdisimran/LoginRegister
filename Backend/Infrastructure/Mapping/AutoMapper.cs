using Application.CQRS.CustomerController.Command;
using AutoMapper;
using Domain;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<User,LoginDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<CustomerProducts,CustomerProductsDTO>().ReverseMap(); 
            CreateMap<Customers,CustomerDTO>().ReverseMap();
            CreateMap<Customers, AddCustomer>();
        }
    }
}
