using Infrastructure.Model;

namespace Model.Entities
{
    public class Employee: AuditableEntity<int>
    {
        
        public string FirstName { get; set; }
        public string LastName {  get; set; }
        public string? City {  get; set; }
        public string? Country {  get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? UserName {  get; set; }
        public string? Password {  get; set; }

      
    }
}
