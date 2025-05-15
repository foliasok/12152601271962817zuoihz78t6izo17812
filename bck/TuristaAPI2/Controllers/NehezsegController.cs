using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuristaAPI2.Models;

namespace TuristaAPI2.Controllers
{
    [Route("Nehezseg")]
    [ApiController]
    public class NehezsegController : ControllerBase
    {
        private readonly TuristadbContext _context;

        public NehezsegController(TuristadbContext context)
        {
            _context = context;
        }
        [HttpPost("Uj")]
        public async Task<ActionResult> Post(Nehezseg nehezseg)
        {
            if (nehezseg != null)
            {
                if (!_context.Nehezsegs.Select(x => x.Jelzes).ToList().Contains(nehezseg.Jelzes))
                {
                    await _context.Nehezsegs.AddAsync(nehezseg);
                    await _context.SaveChangesAsync();
                    return Ok("Sikeres mentés.");
                }
                else
                {
                    return StatusCode(406, $"Már létező jelzés: {nehezseg.Jelzes}");
                }
            }
            Exception e = new Exception();
            return StatusCode(400, $"Hiba a rögzítés közben: {e.Message}");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var letezo = await _context.Nehezsegs.FindAsync(id);
            if (letezo == null)
            {
                return StatusCode(404, "Nem létező nehézségi fok.");
            }
            _context.Nehezsegs.Remove(letezo);
            await _context.SaveChangesAsync();
            return Ok("Sikeres törlés.");
        }
    }
}
