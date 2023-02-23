using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Domain.Enums
{
    public enum StatusType:byte
    {
        Shipping = 10,
        Completed = 20,
        Rejected = 30
    }
}
