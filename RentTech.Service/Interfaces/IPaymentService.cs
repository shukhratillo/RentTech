using RentTech.Domain.Entities;
using RentTech.Service.DTOs;
using RentTech.Service.Helpers;
using System;
using System.Collections.Generic;

namespace RentTech.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<Response<Payment>> CreateAsync(PaymentCreationDto techpayment);
        Task<Response<Payment>> UpdateAsync(long id, PaymentCreationDto techpayment);
        Task<Response<bool>> DeleteAsync(long id);
        Task<Response<Payment>> GetByIdAsync(long id);
        Task<Response<List<Payment>>> GetAllAsync();
    }
}
