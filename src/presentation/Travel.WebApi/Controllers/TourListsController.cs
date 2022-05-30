using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Data.Context;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourListsController : ControllerBase
    {
        private readonly TravelDbContext travelDb;

        public TourListsController(TravelDbContext travelDbContext)
        {
            travelDb = travelDbContext;
        }

        [HttpGet]
        public IActionResult GET()
        {
            return Ok(travelDb.TourLists);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourList tourList)
        {
            await travelDb.TourLists.AddAsync(tourList);
            await travelDb.SaveChangesAsync();

            return Ok(tourList);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            

            var _tourList = await travelDb.TourLists.SingleOrDefaultAsync(tb => tb.Id == id);

            if (_tourList == null)
            {
                return NotFound();
            }

            travelDb.TourLists.Remove(_tourList);
            await travelDb.SaveChangesAsync();

            return Ok(_tourList);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourList tourLists)
        {
            travelDb.TourLists.Update(tourLists);
            await travelDb.SaveChangesAsync();

            return Ok(tourLists);
        }
    }
}
