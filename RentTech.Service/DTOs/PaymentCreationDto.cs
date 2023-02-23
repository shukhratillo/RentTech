using RentTech.Domain.Enums;

namespace RentTech.Service.DTOs
{
    public class PaymentCreationDto
    {
        public PaymentType Type { get; set; }
        public long OrderId { get; set; }
        public bool IsPaid { get; set; }
    }
}
