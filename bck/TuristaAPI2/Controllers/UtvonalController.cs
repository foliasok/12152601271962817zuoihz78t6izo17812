using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using TuristaAPI2.Models;

namespace TuristaAPI2.Controllers
{
    [Route("Utvonal")]
    [ApiController]
    public class UtvonalController : ControllerBase
    {
        private readonly TuristadbContext _context;

        public UtvonalController(TuristadbContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var utvonalak = await _context.Utvonals.ToListAsync();
                if (utvonalak != null)
                {
                    return Ok(utvonalak);
                }
            }
            catch (Exception e)
            {
                
                return StatusCode(400, "Hiba a beolvasás közben:" + e.Message);
            }
            return BadRequest();
        }
        [HttpGet("ById")]
        public async Task<ActionResult> GetById(int id)
        {
            var utvonal = await _context.Utvonals.FindAsync(id);
            if (utvonal == null)
            {
                return StatusCode(419, "Valószínűleg nincs ilyen túra.");
            }
            return Ok(utvonal);
        }
    }
}
