using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Entities;

namespace OnlineAlısveris.Areas.AdminPanel.Models.ViewModels
{
    public class ProductAddViewModel
    {
        public List<Category> CategoryList { get; set; } //= new List<Category>();
        public List<Product> ProductList { get; set; }

 
           
        //public List<SelectListItem> CategoryListItems { get; set; } //= new List<SelectListItem>();
        //public List<Product> ProductList { get; set; }
        //public List<Category> CategoryList { get; set; }
    }
}
