using RentTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Service.DTOs
{
    public class OrderCreationDto
    {
        public ICollection<Product> Products { get; set; }
        public PaymentCreationDto Payment { get; set; }
       

    }
}

