using System.Collections.Generic;

namespace EF.GlobalFilters.EntityFramework.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public virtual List<CreditCard> CreditCards { get; set; }
    }
}