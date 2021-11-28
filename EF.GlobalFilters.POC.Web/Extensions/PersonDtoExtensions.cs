using System.Linq;
using EF.GlobalFilters.EntityFramework.Entities;
using EF.GlobalFilters.POC.Web.Models;

namespace EF.GlobalFilters.POC.Web.Extensions
{
    internal static class PersonDtoExtensions
    {
        internal static PersonDto ToDto(this Person entity)
        {
            var personDto = new PersonDto
            {
                Id = entity.Id,
                FullName = $"{entity.FirstName} {entity.LastName}",
                Cards = entity.CreditCards.Select(c => c.ToDto()).ToList()
            };

            return personDto;
        }
    }
}