using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Entities;
using OnlineAlısveris.ApiServices;
using OnlineAlısveris.Areas.AdminPanel.APITypes;
using OnlineAlısveris.Areas.AdminPanel.Filters;
using OnlineAlısveris.Areas.AdminPanel.Models.ViewModels;
using System.Text.Json;


namespace OnlineAlısveris.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [CheckSession]

    public class ProductController : Controller
    {
        #region Api olmadan çalışan product
        //    private readonly ICategoryManager _catManager;
        //    private readonly IProductManager _prdManager;
        //    private readonly IMapper _mapper;

        //    public ProductController(
        //        ICategoryManager catManager,
        //        IProductManager prdManager,
        //        IMapper mapper)

        //    {
        //        _catManager = catManager;
        //        _prdManager = prdManager;
        //        _mapper = mapper;
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> List()
        //    {
        //        ProductListViewModel viewModel = new();
        //        await _prdManager.GetProducts("Category");


        //        // If there are two Include tables, instead of using navProp, we can pass it as (null, "Category", "Supplier")

        //        viewModel.ProductList = await _prdManager.GetProducts("Category");
        //        viewModel.CategoryList = await _catManager.GetCategories();


        //        return View(viewModel);
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> Add()
        //    {
        //        using (var ctx = new ECommerceDbContext())
        //        {
        //            var categories = ctx.Categories.ToList();
        //            return View(categories);
        //        }
        //    }
        //    // bunu yukarıda asycn methoda çevirdim eğer ürün eklemez ise aşağıdaki kodu tekrar açacağım
        //    //public async Task<IActionResult> Add()
        //    //{
        //    //    using (var ctx = new ECommerceDbContext())
        //    //    {
        //    //        var categories = ctx.Categories.ToList();
        //    //        return View(categories);
        //    //    }
        //    //}

        //    #region Burasını da asycn methoda çevirdim eğer hata olursa burasını da açaccağım
        //    //[HttpPost]
        //    //public async Task<IActionResult> Add(ProductAddDto dto)
        //    //{
        //    //    #region VALIDASYON ORNEGİ
        //    //    List<Category> categories;
        //    //    using (var ctx = new ECommerceDbContext())
        //    //    {

        //    //        categories = ctx.Categories.ToList();

        //    //    }

        //    //    if (dto.CategoryId == -1)
        //    //    {
        //    //        ViewBag.Errormessage = "Lütfen kategori seçiniz";
        //    //        return View(categories);
        //    //    }
        //    //    #endregion

        //    //    var entity = _mapper.Map<Product>(dto);



        //    //    #region Dosyayı sunucuya upload et

        //    //    var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";

        //    //    foreach (var item in dto.Photos)
        //    //    {
        //    //        #region UPLOAD
        //    //        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";

        //    //        using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
        //    //        {
        //    //            await item.CopyToAsync(fs);
        //    //            fs.Close();
        //    //        }
        //    //        #endregion
        //    //        #region PRODUCTPHOTO INSERT
        //    //        var productPhoto = new ProductPhoto();
        //    //        entity.ProductPhotos.Add(productPhoto);

        //    //        //productPhoto.ProductId = entity.ProductId;
        //    //        productPhoto.PhotoPath = $@"\productImages\{fileName}";

        //    //        #endregion
        //    //    }

        //    //    await _prdRepo.InsertAsync(entity);
        //    //    #endregion


        //    //    return RedirectToAction("List");

        //    //}
        //    #endregion



        //    [HttpPost]
        //    public async Task<IActionResult> Add(ProductAddDto dto)
        //    {
        //        #region VALIDASYON ORNEGİ
        //        List<Category> categories;
        //        using (var ctx = new ECommerceDbContext())
        //        {

        //            categories = ctx.Categories.ToList();

        //        }

        //        if (dto.CategoryId == -1)
        //        {
        //            ViewBag.Errormessage = "Lütfen kategori seçiniz";
        //            return View(categories);
        //        }
        //        #endregion

        //        var entity = new Product();
        //        entity.Name = dto.Name;
        //        entity.Price = dto.Price;
        //        entity.Stock = dto.Stock;
        //        entity.CategoryId = dto.CategoryId;



        //        #region Dosyayı sunucuya upload et

        //        var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";

        //        foreach (var item in dto.Photos)
        //        {
        //            #region UPLOAD
        //            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";

        //            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
        //            {
        //                await item.CopyToAsync(fs);
        //                fs.Close();
        //            }
        //            #endregion
        //            #region PRODUCTPHOTO INSERT
        //            var productPhoto = new ProductPhoto();
        //            entity.ProductPhotos.Add(productPhoto);

        //            //productPhoto.ProductId = entity.ProductId;
        //            productPhoto.PhotoPath = $@"\productImages\{fileName}";

        //            #endregion
        //        }

        //        await _prdManager.Insert(dto);
        //        #endregion


        //        return RedirectToAction("List");




        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> Details(int id)
        //    {
        //        var product = await _prdManager.GetById(id, "Category", "ProductPhotos");

        //        return View(product);

        //    }

        //    [HttpPost]
        //    public async Task<JsonResult> GetProductById(int id)
        //    {
        //        var jsonObj = _prdManager.GetProductById(id, "ProductPhotos");

        //        return Json(jsonObj);
        //    }


        //    public IActionResult Edit(int id)
        //    {
        //        using (var ctx = new ECommerceDbContext())
        //        {
        //            var entity = ctx.Products.SingleOrDefault(x => (int)x.Id == id);
        //            return View(entity);
        //        }
        //    }


        //    //[HttpPost]
        //    //public async Task<IActionResult> Edit(ProductEditDto dto)
        //    //{
        //    //    // VALIDATION

        //    //    using (var ctx = new ECommerceDbContext())
        //    //    {
        //    //        var entity = ctx.Products.FirstOrDefault(x => (int)x.Id == dto.ProductId);

        //    //        entity.Name = dto.Name;
        //    //        entity.Price = dto.Price;
        //    //        entity.Stock = dto.Stock;



        //    //        if (dto.Photo != null)
        //    //        {
        //    //            #region YENI DOSYAYI UPLOAD ET
        //    //            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";

        //    //            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

        //    //            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
        //    //            {
        //    //                await dto.Photo.CopyToAsync(fs);
        //    //                fs.Close();
        //    //            }

        //    //            #endregion

        //    //            #region ESKI DOSYAYI SIL

        //    //            System.IO.File.Delete($"{rootPath}{entity.PhotoPath.Replace("\\productImages\\", "")}");

        //    //            #endregion

        //    //            using (var stream = new MemoryStream())
        //    //            {
        //    //                await dto.Photo.CopyToAsync(stream);

        //    //                stream.Close();
        //    //            }

        //    //            entity.PhotoPath = $@"\productImages\{fileName}";
        //    //        }

        //    //        await _prdRepo.UpdateAsync(entity);


        //    //        return RedirectToAction("List");
        //    //    }


        //}
        #endregion

        private readonly IApiService _apiService;
        private readonly IProductManager _prdManager;
        private readonly IMapper _mapper;
        public ProductController(IApiService apiService, IProductManager prdManager, IMapper mapper)
        {
            _apiService = apiService;
            _prdManager = prdManager;
            _mapper = mapper;
        }
        // ürünleri fiyat aralığına göre Listeleme
        //[HttpGet]
        //public async Task<IActionResult> ListByPriceRange(decimal min, decimal max, string[] includeList)
        //{
        //    // API'den ürünleri al
        //    var viewModel = await _apiService.GetData<List<ProductResponse>>($"GetProductsByPriceRange?min={min}&max={max}&includeList={string.Join(",", includeList)}", token: null);

        //    // Eğer sonuç yoksa uygun bir mesaj gönder
        //    if (viewModel == null || !viewModel.Any())
        //    {
        //        ViewBag.ErrorMessage = "No products found in the specified price range.";
        //        return View(new List<ProductResponse>()); // Boş bir liste döndür
        //    }

        //    return View(viewModel); // Ürünleri view'a gönder
        //}

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _apiService.GetData<List<ProductResponse>>("products", token: null);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Add()
        {


            using (var ctx = new ECommerceDbContext())
            {
                var model = new ProductAddViewModel();
                model.CategoryList = ctx.Categories.ToList();
                return View(model);

            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto dto)
        {
            #region VALIDASYON ORNEGİ
            List<Category> categories;
            using (var ctx = new ECommerceDbContext())
            {

                categories = ctx.Categories.ToList();

            }

            if (dto.CategoryId == -1)
            {
                ViewBag.Errormessage = "Lütfen kategori seçiniz";
                return View(categories);
            }
            #endregion



            var requestObject = new ProductPostRequest();
            requestObject.Description = dto.Description;
            requestObject.Price = dto.Price;
            requestObject.CategoryId = dto.CategoryId;
            requestObject.Stock = dto.Stock;
            requestObject.Name = dto.Name;
            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";
            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
            {
                await dto.Photo.CopyToAsync(fs);
                requestObject.PhotoPath = $@"\productImages\{fileName}";
                fs.Close();
            }
            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var postResult = await _apiService.PostData("products", jsonPostData, token: null);
            Console.WriteLine(jsonPostData);


            if (postResult)
                return RedirectToAction("List");


            return Json(new { IsSuccess = false });


            //return RedirectToAction("List"); ///burası şimdilik dursun işime yarayabilir
        }




        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var product = await _apiService.GetByIdAsync(id, "Category", "ProductPhotos");

        //    return View(product);

        //}

        #region ESKİ YAPTIĞIM
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var product = await _apiService.GetData<ProductResponse>($"products/{id}");
        //    return View(product);
        //}

        //public async Task<IActionResult> Edit(ProductEditDto dto)
        //{
        //    // Ürün bilgilerini ayarla
        //    var requestObject = new ProductPutRequest
        //    {
        //        Name = dto.Name,
        //        Price = dto.Price,
        //        Stock = dto.Stock,
        //        Id = dto.CategoryId,
        //        Photo = dto.Photo
        //    };

        //    var productPhotos = new List<ProductPhoto>();
        //    var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";


        //    foreach (var photo in dto.Photo)
        //    {
        //        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";
        //        using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
        //        {
        //            await photo.CopyToAsync(fs);

        //            fs.Close();
        //        }


        //        productPhotos.Add(new ProductPhoto
        //        {
        //            PhotoPath = $@"\productImages\{fileName}",

        //        });
        //    }
        //    return Ok();
        //}
        #endregion

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var product = await _apiService.GetData<ProductResponse>($"products/{id}", token: null);
            var categories = await _apiService.GetData<List<Category>>("categories", token: null); // Tüm kategorileri al

            product.CategoryList = categories; // Kategori listesini ekle

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                ModelState.AddModelError("", "Geçersiz ürün bilgileri.");
                return View(dto);
            }

            var requestObject = new ProductPutRequest
            {
                Id = dto.Id, // Burada Id'nin doğru alındığından emin olun
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };

            // Fotoğraf güncelleme kısmı
            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";
            if (dto.Photo != null)
            {
                // Eski fotoğrafın yolu var mı kontrol et
                if (!string.IsNullOrEmpty(dto.PhotoPath))
                {
                    var oldFilePath = Path.Combine(rootPath, dto.PhotoPath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath); // Eski dosyayı sil
                    }
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

                using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
                {
                    await dto.Photo.CopyToAsync(fs);
                    requestObject.PhotoPath = $@"\productImages\{fileName}";
                }
            }
            else
            {
                // Yeni bir fotoğraf yüklenmediyse eski fotoğrafı koru
                requestObject.PhotoPath = dto.PhotoPath;
            }

            // API çağrısını yap
            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var result = await _apiService.PutData("products", jsonPostData, token: null);

            if (result)
                return RedirectToAction("List");

            else
                throw new Exception("Hata");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteData($"products/{id}");

            if (result)

                return Json(new { IsSuccess = true });

            else
                throw new Exception("hata oldu");

        }


    }

}