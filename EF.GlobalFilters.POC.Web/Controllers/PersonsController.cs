using System.Linq;
using System.Threading.Tasks;
using EF.GlobalFilters.EntityFramework;
using EF.GlobalFilters.POC.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF.GlobalFilters.POC.Web.Controllers
{
    [Route("person")]
    public class PersonsController: Controller
    {
        private readonly GlobalFiltersDbContext _filtersDbContext;

        public PersonsController(GlobalFiltersDbContext filtersDbContext)
        {
            _filtersDbContext = filtersDbContext;
        }

        [HttpGet]
        [Route("{onlyActiveCards:bool}")]
        public async Task<IActionResult> GetPersons([FromRoute] bool onlyActiveCards)
        {
            var basePersonsQuery = _filtersDbContext
                .Persons
                .Include(c => c.CreditCards)
                .AsQueryable();

            if (!onlyActiveCards)
            {
                basePersonsQuery = basePersonsQuery.IgnoreQueryFilters();
            }

            var personsList = await basePersonsQuery.ToListAsync();

            var personsDtosList = personsList
                .Select(p => p.ToDto());
            
            return Ok(personsDtosList);
        }
    }
}