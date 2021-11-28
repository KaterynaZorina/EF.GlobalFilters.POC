using System.Linq;
using System.Threading.Tasks;
using EF.GlobalFilters.EntityFramework;
using EF.GlobalFilters.POC.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF.GlobalFilters.POC.Web.Controllers
{
    [Route("card")]
    public class CardsController: Controller
    {
        private readonly GlobalFiltersDbContext _filtersDbContext;

        public CardsController(GlobalFiltersDbContext filtersDbContext)
        {
            _filtersDbContext = filtersDbContext;
        }

        [HttpGet]
        [Route("{onlyActive:bool}")]
        public async Task<IActionResult> GetCards([FromRoute] bool onlyActive)
        {
            var baseCardsQuery = _filtersDbContext
                .CreditCards
                .AsQueryable();

            if (!onlyActive)
            {
                baseCardsQuery = baseCardsQuery.IgnoreQueryFilters();
            }

            var cardsList = await baseCardsQuery.ToListAsync();

            var cardsDtosList = cardsList.Select(c => c.ToDto());

            return Ok(cardsDtosList);
        }
    }
}