using Business.Managers;
using DataAccesLayer.Interface;

namespace Business.Abstract
{
    public interface IProductPhotoManager
    {
        Task Delete(int id);
    }
}
