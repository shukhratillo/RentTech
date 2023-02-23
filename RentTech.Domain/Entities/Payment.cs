using RentTech.Domain.Commons;
using RentTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentTech.Domain.Enums;

namespace RentTech.Domain.Entities
{
    public class Payment:Auditable
    {
        public PaymentType PaymentType { get; set; }
        public bool IsPaid { get; set; }
        public long OrderId { get; set; }
    }
}
