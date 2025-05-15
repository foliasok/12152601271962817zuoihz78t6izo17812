using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuristaAPI2.Models;

namespace TuristaAPI2.Controllers
{
    [Route("Tura")]
    [ApiController]
    public class TuraController : ControllerBase
    {
        private readonly TuristadbContext _context;

        public TuraController(TuristadbContext context)
        {
            _context = context;
        }
        [HttpPut("Modositas")]
        public async Task<ActionResult> Put(Tura tura)
        {
            var letezik = await _context.Turas.FindAsync(tura.Id);
            if (letezik == null)
            {
                return StatusCode(404, "Hiányzó túra.");
            }
            letezik.Koltseg = tura.Koltseg;
            letezik.Maxletszam = tura.Maxletszam;
            letezik.Idopont = tura.Idopont;
            letezik.UtvonalId = tura.UtvonalId;
            letezik.TuravezetoId = tura.TuravezetoId;
            _context.Turas.Update(letezik);
            await _context.SaveChangesAsync();
            return Ok("Sikeres módosítás.");
        }
    }
}
