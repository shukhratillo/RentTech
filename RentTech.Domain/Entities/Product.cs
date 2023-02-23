using RentTech.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Domain.Entities
{
    public class Product:Auditable
    {
        public string ProductName { get;set; }                      
        public string ProductDescription { get;set; }
        public long Count { get;set; }
        public decimal RentPrice { get;set; }
    }
}
