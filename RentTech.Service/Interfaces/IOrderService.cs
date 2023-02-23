using RentTech.Domain.Entities;
using RentTech.Domain.Enums;
using RentTech.Service.DTOs;
using RentTech.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Response<Order>> CreateAsync(OrderCreationDto ordertech);
        Task<Response<Order>> UpdateAsync(long id, OrderCreationDto ordertech);
        Task<Response<Order>> GetByIdAsync(long id);
        Task<Response<List<Order>>> GetAllAsync();
        Task<Response<Order>> ChangeStatus(long id, StatusType status);
    }
}
