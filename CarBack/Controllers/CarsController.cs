using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBack.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBack.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly EFDbContext _context;

        public CarsController(EFDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CarList()
        {
            //var cars = _context.Cars.Select(d => new DogVM
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    Image = d.Image
            //}).ToList();

            return Ok();
        }
    }
}