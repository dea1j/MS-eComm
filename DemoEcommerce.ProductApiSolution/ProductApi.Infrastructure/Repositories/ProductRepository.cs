using eCommerce.SharedLibrary.Logs;
using eCommerce.SharedLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ProductApi.Application.Interfaces;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Data;
using System.Linq.Expressions;

namespace ProductApi.Infrastructure.Repositories
{
    public class ProductRepository(ProductDbContext context) : IProduct
    {
        public async Task<Response> CreateAsync(Product entity)
        {
            try
            {
                // check if product already exist
                var getProduct = await GetByAsync(_ => _.Name!.Equals(entity.Name));
                if (getProduct is not null && !string.IsNullOrEmpty(getProduct.Name))
                    return new Response(false, $"{entity.Name} already added");

                var currentEntity = context.Products.Add(entity).Entity;
                await context.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.Id > 0)
                    return new Response(true, $"{entity.Name} added to database successfully");
                else
                    return new Response(false, $"Error occured while adding {entity.Name}");
            }
            catch (Exception ex)
            {
                // Log original exception
                LogException.LogExceptions(ex);

                // Display scary-free message to client
                return new Response(false, "Error occured while adding new product");
            }
        }

        public async Task<Response> DeleteAsync(Product entity)
        {
            try
            {
                var product = await FindByIdAsync(entity.Id);
                if(product is null)
                    return new Response(false, $"{entity.Name} not found");
                
                context.Products.Remove(entity);
                await context.SaveChangesAsync();
                return new Response(true, $"{entity.Name} deleted successfully");
            }
            catch (Exception ex)
            {
                // Log original exception
                LogException.LogExceptions(ex);

                // Display scary-free message to client
                return new Response(false, "Error occured while adding new product");
            }
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            try
            {
                var product = await context.Products.FindAsync(id);
                return product is not null ? product : null;
            }
            catch (Exception ex)
            {
                // Log original exception
                LogException.LogExceptions(ex);

                throw new Exception("Error occured while retrieving product");
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
            //try
            //{
            //    var product = await context.Products.ToListAsync()
            //}
            //catch (Exception ex)
            //{
            //    // Log original exception
            //    LogException.LogExceptions(ex);

            //    // Display scary-free message to client
            //    throw new InvalidOperationException("Error Occured while retrieving products");
            //}
        }

        public Task<Product> GetByAsync(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
