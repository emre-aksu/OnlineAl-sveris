using Infrastructure.Model;

namespace Model.Dtos
{
    public class ProductPhotoDto : IDto
    {
        public int ProductId { get; set; }
        public string? PhotoPath { get; set; }
    }
}
