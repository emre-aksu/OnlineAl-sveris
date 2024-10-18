using Business.Abstract;
using Business.Managers;
using Business.Mapping.Automapper.Profiles;
using Business.Validators.FluentValidation;
using DataAccesLayer.Interface;
using DataAccesLayer.Repositories;
using FluentValidation;
using Model.Dtos;
using OnlineAlısveris.ApiServices;
using System.Text.Json.Serialization;

namespace OnlineAlısveris
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                            .AddJsonOptions(options =>
                                            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddSession();// Session, uygulama genelinde kullanıma açılıyor
            builder.Services.AddHttpContextAccessor();

            //HTTPCLIENT ILE API KABERLESMESI ICIN GECERLI
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IApiService, ApiService>();
            //-------------------------------------------------------------------





            //IoC'e dependeny injection ile enjekte edileccek nesnelerin neler olduğunu register ediyoruz (Entity framework ile çalışan Repository objelerini bu arayüzlere yaratılıp verilmesi gerektiğini söylemiş oluyoruz.)
            //------------------------------------------------------------------------------------------------------------
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();

            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IProductPhotoManager, ProductPhotoManager>();
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
            //------------------------------------------------------------------------------------------------------------

            //Automapper için;
            //builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //2.yöntem
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            //--------------------------------------------------------------------------------------------------


            //Login dto tipindeki bir nesnenin validasyonu yapılması gerektiğinde o tipe ait kurallar sınıfından işletilsin.
            builder.Services.AddScoped<IValidator<LogInDto>, LogInDtoValidator>();
            builder.Services.AddScoped<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
            builder.Services.AddScoped<IValidator<ProductAddDto>, ProductAddDtoValidator>();
          

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // Session, uygulama genelinde kullanıma açılıyor

            app.UseAuthorization();

            app.MapAreaControllerRoute(
                name: "adminPanelDefault",
                areaName: "AdminPanel",
                pattern: "/admin/{controller=Authentication}/{action=LogIn}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}