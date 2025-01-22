using eCommerce.SharedLibrary.Logs;
using eCommerce.SharedLibrary.Responses;
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
            throw new NotImplementedException();
            //try
            //{
            //    var getProduct = await GetByAsync(_ => _.Name!.Equals(entity.Name));
            //}
            //catch (Exception ex)
            //{
            //    // Log original exception
            //    LogException.LogExceptions(ex);

            //    // Display scary-free message to client
            //    return new Response(false, "Error occured while adding new product");
            //}
        }

        public Task<Response> DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
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
