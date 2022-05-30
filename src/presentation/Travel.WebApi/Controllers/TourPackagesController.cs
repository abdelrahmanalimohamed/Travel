using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Data.Context;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourPackagesController : ControllerBase
    {
        private readonly TravelDbContext travelDb;

        public TourPackagesController(TravelDbContext travelDbContext)
        {
            travelDb = travelDbContext;
        }

        [HttpGet]
        public IActionResult GET()
        {
            return Ok(travelDb.TourPackages);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourPackage tourPackage)
        {
            await travelDb.TourPackages.AddAsync(tourPackage);
            await travelDb.SaveChangesAsync();

            return Ok(tourPackage);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tourpackage = (from a in travelDb.TourPackages
                               where a.Id == id
                               select a).FirstOrDefault();

            var _tourpackage = await travelDb.TourPackages.SingleOrDefaultAsync(tb => tb.Id == id);

            if (_tourpackage == null)
            {
                return NotFound();
            }

            travelDb.TourPackages.Remove(_tourpackage);
            await travelDb.SaveChangesAsync();

            return Ok(_tourpackage);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id , [FromBody] TourPackage tourPackage)
        {
            travelDb.TourPackages.Update(tourPackage);
            await travelDb.SaveChangesAsync();

            return Ok(tourPackage);
        }
    }
}
