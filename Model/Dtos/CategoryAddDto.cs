using Infrastructure.Model;
using Microsoft.AspNetCore.Http;

namespace Model.Dtos
{
    public class CategoryAddDto:IDto
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
