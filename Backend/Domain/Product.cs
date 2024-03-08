using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public float SellingPrice { get; set; }
        public float PurchasePrice { get; set; }
        public DateTime SellingDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
