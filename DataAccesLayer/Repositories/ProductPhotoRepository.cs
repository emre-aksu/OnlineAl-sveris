using DataAccesLayer.Interface;
using DataAccess.Context;
using Infrastructure.DataAccesLayer;
using Model.Entities;

namespace DataAccesLayer.Repositories
{
    public class ProductPhotoRepository : BaseRepository<ProductPhoto, int, ECommerceDbContext>, IProductPhotoRepository
    {
        public async void Delete(int id)
        {
            using ECommerceDbContext ctx = new();
            var entity = ctx.ProductPhotos.SingleOrDefault(x => (int)x.Id == id);
            ctx.ProductPhotos.Remove(entity);
            ctx.SaveChanges();
        }
    }
}
