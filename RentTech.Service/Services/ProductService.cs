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
    public class ProductService : IProductService
    {

        private readonly GenericRepository<Product> genericRepository = new GenericRepository<Product>();


        public async Task<Response<Product>> CreateAsync(ProductCreationDto tech)
        {
            var models = await this.genericRepository.GetAllAsync();
            var model = models.FirstOrDefault(x => x.ProductName == tech.Name);

            if (model is not null)
            {
                model.Count += tech.Count;
                await genericRepository.UpdateAsync(model.Id, model);

                return new Response<Product>()
                {
                    StatusCode = 403,
                    Message = "Product already exists",
                    Value = null
                };
            }

            var mappedModel = new Product()
            {
                ProductName = tech.Name,
                ProductDescription = tech.Description,
                Count = tech.Count,
                RentPrice = tech.RentalPrice,
            };
            var result = await this.genericRepository.CreateAsync(mappedModel);

            return new Response<Product>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    

        public async Task<Response<bool>> DeletAsync(long id)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "Product is not found",
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

        public async Task<Response<List<Product>>> GetAllAsync()
        {
            var model = await this.genericRepository.GetAllAsync();
            return new Response<List<Product>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<Response<Product>> GetByIdAsync(long id)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<Product>()
                {
                    StatusCode = 404,
                    Message = "Product is not found",
                    Value = null
                };

            return new Response<Product>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<Response<Product>> UpdateAsync(long id, ProductCreationDto tech)
        {
            var model = await this.genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<Product>()
                {
                    StatusCode = 404,
                    Message = "Product is not found",
                    Value = null
                };

            var mappedModel = new Product()
            {
                ProductName = tech.Name,
                ProductDescription = tech.Description,
                Count = tech.Count,
                RentPrice = tech.RentalPrice,
            };

            var result = await this.genericRepository.UpdateAsync(id, mappedModel);
            return new Response<Product>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    }
}
