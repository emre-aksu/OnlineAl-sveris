namespace Infrastructure.Model
{
    public abstract class AuditableEntity<TId>:BaseEntity<TId>
    {
        public DateTime? Added { get; set; }
        public DateTime? Modified { get; set; }
        public int? AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
