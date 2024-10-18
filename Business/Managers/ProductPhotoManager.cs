using Business.Abstract;
using DataAccesLayer.Interface;

namespace Business.Managers
{
    public class ProductPhotoManager : IProductPhotoManager
    {
        private readonly IProductPhotoRepository _productPhotoRepo;

        public ProductPhotoManager(IProductPhotoRepository productPhotoRepo)
        {
            _productPhotoRepo = productPhotoRepo;
        }
        public async Task Delete(int id)
        {
            //Logla
            // vs

            _productPhotoRepo.DeleteAsync(id);

        }
    }
}
