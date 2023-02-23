using RentTech.Data.Repositories;
using RentTech.Domain.Entities;
using RentTech.Service.DTOs;
using RentTech.Service.Helpers;
using RentTech.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Service.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly GenericRepository<Payment> genericRepository = new GenericRepository<Payment>();

        public async Task<Response<Payment>> CreateAsync(PaymentCreationDto techpayment)
        {
            var mappedModel = new Payment()
            {
                PaymentType = techpayment.Type,
                OrderId = techpayment.OrderId,
                IsPaid = true
            };
            var result = await this.genericRepository.CreateAsync(mappedModel);

            return new Response<Payment>()
            {
                StatusCode = 201,
                Message = "Success",
                Value = result
            };
        }

        public async Task<Response<bool>> DeleteAsync(long id)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "Payment is not found",
                    Value = false
                };

            await this.genericRepository.DeleteAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async Task<Response<List<Payment>>> GetAllAsync()
        {
            var models = await this.genericRepository.GetAllAsync();
            return new Response<List<Payment>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = models
            };
        }

        public async Task<Response<Payment>> GetByIdAsync(long id)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<Payment>()
                {
                    StatusCode = 404,
                    Message = "Payment is not found",
                    Value = null
                };

            return new Response<Payment>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<Response<Payment>> UpdateAsync(long id, PaymentCreationDto techpayment)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<Payment>()
                {
                    StatusCode = 404,
                    Message = "Payment is not found",
                    Value = null
                };

            var mappedModel = new Payment()
            {
                PaymentType = techpayment.Type
            };
            var result = await this.genericRepository.UpdateAsync(id, mappedModel);

            return new Response<Payment>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    }
}
