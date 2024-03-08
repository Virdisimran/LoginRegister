using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CustomerProductsDTO
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int CustomerId { get; set; }
    }
}
