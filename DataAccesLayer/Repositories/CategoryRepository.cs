using DataAccesLayer.Interface;
using DataAccess.Context;
using Infrastructure.DataAccesLayer;
using Model.Entities;

namespace DataAccesLayer.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int, ECommerceDbContext>, ICategoryRepository
    {
        public async Task<Category> GetByNameAsync(string categoryName)
        {
            return await GetAsync(x => x.Name == categoryName);
        }
    }
}
