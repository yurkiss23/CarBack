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
    public class MakersController : ControllerBase
    {
        private readonly EFDbContext _context;

        public MakersController(EFDbContext context)
        {
            _context = context;
        }

        [HttpGet("select")]
        public IActionResult MakerSelectList()
        {
            var model = _context.Makers
                .Where(m => m.IsShow)
                .Select(m => new MakerSelectVM
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList();

            return Ok(model);
        }
    }
}