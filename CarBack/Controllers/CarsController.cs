using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBack.DAL.Entities;
using CarBack.ViewModels;
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
            var model = _context.Cars.Select(c => new CarVM
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image
            }).ToList();

            return Ok(model);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]CarAddVM model)
        {
            DbCar car = new DbCar
            {
                MakerId = model.MakerId,
                Name = "NoName",
                Image = ""
            };
            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok(car);
        }
    }
}