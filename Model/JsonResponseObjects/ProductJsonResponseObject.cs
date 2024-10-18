using Model.Dtos;

namespace Model.JsonResponseObjects
{
    public class ProductJsonResponseObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductPhotoDto> ProductPhotos { get; set; }
    }
}
