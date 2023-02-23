using RentTech.Data.Repositories;
using RentTech.Domain.Entities;
using RentTech.Domain.Enums;
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
    public class OrderService : IOrderService
    {

        private readonly GenericRepository<Order> genericRepository = new GenericRepository<Order>();
        private readonly IPaymentService paymentService = new PaymentService();

        public async Task<Response<Order>> CreateAsync(OrderCreationDto ordertech)
        {
           
            var paymentResult = await paymentService.CreateAsync(ordertech.Payment);

            if (paymentResult.Value.IsPaid)
            {
                var mappedOrder = new Order()
                {
                    Products = ordertech.Products,
                    Payment = paymentResult.Value,
                    Status = StatusType.Shipping
                };
                var orderResult = await genericRepository.CreateAsync(mappedOrder);

                return new Response<Order>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = orderResult
                };
            }

            return new Response<Order>()
            {
                StatusCode = 402,
                Message = "Payment is not valid",
                Value = null
            };



        }
        public async Task<Response<List<Order>>> GetAllAsync()
        {
            var orders = await this.genericRepository.GetAllAsync();
            return new Response<List<Order>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = orders
            };
        }

        public async Task<Response<Order>> GetByIdAsync(long id)
        {
            var order = await this.genericRepository.GetByIdAsync(id);
            if (order is null)
                return new Response<Order>()
                {
                    StatusCode = 404,
                    Message = "Success",
                    Value = null
                };

            return new Response<Order>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = order
            };
        }

        public async Task<Response<Order>> UpdateAsync(long id, OrderCreationDto ordertech)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<Order>()
                {
                    StatusCode = 404,
                    Message = "Success",
                    Value = null
                };
            var mappedPayment = new Payment()
            {
                PaymentType = ordertech.Payment.Type,
                OrderId = ordertech.Payment.OrderId,
                IsPaid = ordertech.Payment.IsPaid
            };
            var mappedOrder = new Order()
            {
                Products = ordertech.Products,
                Payment = mappedPayment,
                Status = model.Status,
            };

            var orderResult = await this.genericRepository.UpdateAsync(id, mappedOrder);
            return new Response<Order>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = orderResult
            };
        }

         public async Task<Response<Order>> ChangeStatus(long id, StatusType status)
         {
            var order = await genericRepository.GetByIdAsync(id);
            if (order is not null)
            {
                order.Status = status;
                var orderResult = await genericRepository.UpdateAsync(id, order);
                return new Response<Order>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = orderResult
                };
            }

            return new Response<Order>()
            {
                StatusCode = 404,
                Message = "Order is not found",
                Value = null
            };
        }
        
    }
}

