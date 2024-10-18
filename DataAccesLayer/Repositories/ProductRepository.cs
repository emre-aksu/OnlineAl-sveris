using DataAccesLayer.Interface;
using DataAccess.Context;
using Infrastructure.DataAccesLayer;
using Model.Entities;

namespace DataAccesLayer.Repositories
{
    public class ProductRepository:BaseRepository<Product,int, ECommerceDbContext>,IProductRepository
    {
        #region Eğer Include etmem gereken bir kayıt var ise bunu kullanmalıyım
        // INCLUDE ETMEM GEREKEN BİR TABLO VAR İSE BUNU KULLANMALIYIM 
        //public List<Product> GetAll(string navProp = "")
        //{
        //    using ECommerceDbContext ctx = new();
        //    if (!string.IsNullOrEmpty(navProp))
        //        return ctx.Products.Include(navProp).ToList();

        //    return ctx.Products.ToList();
        //}

        // INCLUDE ETMEM GEREKEN BİRDEN FAZLA TABLO VAR İSE BUNU KULLANMALIYIM 
        #endregion

     
        public async Task<List<Product>> GetByCategory(int categoryId)
        {
           
            return await GetAllAsync(x => x.CategoryId == categoryId);
        }
        public async Task<List<Product>> GetByPrice(decimal min, decimal max, bool inclusive = false)
        {
           
            if (inclusive)
            
                return await GetAllAsync(x => x.Price >= min && x.Price <= max);
           
            return await GetAllAsync(x => x.Price > min && x.Price < max);
        } 

    }
}
