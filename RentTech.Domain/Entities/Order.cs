using RentTech.Domain.Commons;
using RentTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Domain.Entities
{
    public class Order:Auditable
    {
        public ICollection<Product> Products { get; set; }
        public StatusType Status { get; set; }
        public Payment Payment { get; set; }
    }
}
