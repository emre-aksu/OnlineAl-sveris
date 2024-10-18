namespace Infrastructure.Model
{
    public abstract class BaseEntity<TId>
    {
        /// <summary>
        /// Ortak sınıfları baseEntity'den kalıtım vererek hepsinde entegre edilmesini sağladık.
        /// Böylelikle kod tekrarı yapmamış oluyoruz
        /// </summary> 
        public TId Id { get; set; } 
       
    }
}
