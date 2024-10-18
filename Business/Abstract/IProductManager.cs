
using Model.Dtos;
using Model.Entities;
using Model.JsonResponseObjects;

namespace Business.Abstract
{
    public interface IProductManager 
    {
        Task<List<Product>> GetProducts(params string[] includeList);
        Task<List<Product>> GetByPrice(decimal min,decimal max);
        Task<Product> GetById(int id, params string[] includeList);
        Task<ProductJsonResponseObject> GetProductById(int id, params string[] includeList);

 
       
    }
}
