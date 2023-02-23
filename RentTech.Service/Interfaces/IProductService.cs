using RentTech.Domain.Entities;
using RentTech.Service.DTOs;
using RentTech.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentTech.Service.Interfaces
{
    public interface IProductService
    {
        Task<Response<Product>> CreateAsync(ProductCreationDto tech);
        Task<Response<Product>> UpdateAsync(long id, ProductCreationDto tech);


        Task<Response<bool>> DeletAsync(long id);
        Task<Response<Product>> GetByIdAsync(long id);
        Task<Response<List<Product>>> GetAllAsync();
    }
}
