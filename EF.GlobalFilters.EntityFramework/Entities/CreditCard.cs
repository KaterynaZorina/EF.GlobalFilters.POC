namespace EF.GlobalFilters.EntityFramework.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }

        public long Number { get; set; }

        public bool IsActive { get; set; }
        
        public virtual Person Owner { get; set; }
    }
}