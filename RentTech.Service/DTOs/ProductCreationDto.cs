using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Service.DTOs
{
    public class ProductCreationDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public decimal RentalPrice { get; set; }
    }
}
