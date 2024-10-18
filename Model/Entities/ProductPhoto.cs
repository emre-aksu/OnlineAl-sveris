using Infrastructure.Model;

namespace Model.Entities
{
    public class ProductPhoto : AuditableEntity<int>
    {
      
        public int ProductId {  get; set; } 
        public string? PhotoPath { get; set; } 
        public Product? Product { get; set; }
    }
}
