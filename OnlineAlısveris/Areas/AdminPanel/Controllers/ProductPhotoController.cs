using Business.Abstract;
using DataAccesLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using OnlineAlısveris.Areas.AdminPanel.Filters;

namespace OnlineAlısveris.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [CheckSession]
    public class ProductPhotoController : Controller
    {
        private readonly IProductPhotoManager _productPhotoManager;
        public ProductPhotoController(IProductPhotoManager productPhotoManager)
        {
            _productPhotoManager = productPhotoManager;
        }

        [HttpPost]
        public async Task<JsonResult> DeletePhoto(int id)
        {
            await _productPhotoManager.Delete(id);


            // KLASORDEN SIL

            return Json(new { IsSuccess = true });

        }
    }
}
