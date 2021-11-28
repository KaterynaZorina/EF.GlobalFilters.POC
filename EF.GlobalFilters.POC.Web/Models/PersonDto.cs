using System.Collections.Generic;

namespace EF.GlobalFilters.POC.Web.Models
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<CardDto> Cards { get; set; }
    }
}