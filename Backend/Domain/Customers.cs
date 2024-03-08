using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customers
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Username { get; set; }
        public string? Email { get; set; }
        public ICollection<CustomerProducts>? CustomerProducts { get; set; }

    }
}
