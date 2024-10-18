using Infrastructure.DataAccess.Interface;
using Model.Entities;


namespace DataAccesLayer.Interface;

public interface IProductRepository:IRepository<Product, int>
{


    Task<List<Product>> GetByCategory(int categoryId);
    Task<List<Product>> GetByPrice(decimal min, decimal max, bool inclusive=false);
   
}
