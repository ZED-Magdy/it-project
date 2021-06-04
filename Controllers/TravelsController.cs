using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ITProject.Controllers
{
    [ApiController]
    [Route("/api/travels")]
    public class TravelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TravelsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{from}/{to}")]
        public async Task<IActionResult> Get(int from, int to)
        {
            var travels = await _context.Travels
                                        .Include(t => t.FromCity)
                                        .Include(t => t.ToCity)
                                        .Where(t => t.FromCityId == from && t.ToCityId == to)
                                        .OrderByDescending(t => t.Id)
                                        .ToListAsync();
            return Ok(travels);
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(cities);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Reservation(int id)
        {
            var travel = await _context.Travels.FirstOrDefaultAsync(t => t.Id == id);
            if(travel == null)
            {
                return NotFound();
            }
            if(travel.AvailableSeats > 0)
            {
                travel.AvailableSeats--;
            }
            else{
                return BadRequest();
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedData()
        {
            var rand = new Random();
            var travels = new List<Travel>();
            var cities = new List<City>();
            for (int i = 0; i <= 25; i++){
                cities.Add(new City
                {
                    Name = Faker.Address.City()
                });
            }
            for (int i = 0; i <= 500; i++)
            {
                travels.Add(new Travel
                {
                    Title = Faker.Address.City() + " to " + Faker.Address.City(),
                    FromCityId = rand.Next(1, 25),
                    ToCityId = rand.Next(1, 25),
                    AvailableSeats = rand.Next(0,25),
                    StartAt = DateTime.Now.AddHours(rand.Next(1, 24)).AddMinutes(rand.Next(1, 60))
                });
            }
            _context.Cities.AddRange(cities);
            await _context.SaveChangesAsync();
            _context.Travels.AddRange(travels);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
