using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunnelAPI.Data;
using TunnelAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TunnelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly TunnelApiDbContext _context;

        public RendezVousController(TunnelApiDbContext context)
        {
            _context = context;
        }

        // GET: api/RendezVous
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RendezVousModel>>> GetRendezVousList()
        {
            try
            {
                var rendezVousList = await _context.RendezVous.ToListAsync();
                return Ok(rendezVousList);
            }
            catch
            {
                return StatusCode(500, "Error retrieving data.");
            }
        }

        // GET: api/RendezVous/{rendezVousId}
        [HttpGet("{rendezVousId}")]
        public async Task<ActionResult<RendezVousModel>> GetRendezVous(int rendezVousId)
        {
            var rendezVous = await _context.RendezVous.FindAsync(rendezVousId);
            if (rendezVous == null)
            {
                return NotFound(new { message = "RendezVous not found" });
            }

            return Ok(rendezVous);
        }

        // POST: api/RendezVous
        [HttpPost]
        public async Task<ActionResult<RendezVousModel>> AddRendezVous(RendezVousModel rendezVous)
        {
            try
            {
                _context.RendezVous.Add(rendezVous);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetRendezVousList), new { id = rendezVous.RendezVousId }, rendezVous);
            }
            catch
            {
                return StatusCode(500, "Error saving data.");
            }
        }

       

        // PUT: api/RendezVous/{rendezVousId}
        [HttpPut("{rendezVousId}")]
        public async Task<IActionResult> UpdateRendezVous(int rendezVousId, RendezVousModel rendezVous)
        {
            if (rendezVousId != rendezVous.RendezVousId)
            {
                return BadRequest(new { message = "RendezVousId mismatch" });
            }

            var existingRendezVous = await _context.RendezVous.FindAsync(rendezVousId);
            if (existingRendezVous == null)
            {
                return NotFound(new { message = "RendezVous not found" });
            }
            existingRendezVous.CodeClient = rendezVous.CodeClient;
            existingRendezVous.Nom = rendezVous.Nom;
            existingRendezVous.Prenom = rendezVous.Prenom;
            existingRendezVous.Date = rendezVous.Date;
            existingRendezVous.Notes = rendezVous.Notes;

            _context.Entry(existingRendezVous).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/RendezVous/{rendezVousId}
        [HttpDelete("{rendezVousId}")]
        public async Task<IActionResult> DeleteRendezVous(int rendezVousId)
        {
            var rendezVous = await _context.RendezVous.FindAsync(rendezVousId);
            if (rendezVous == null)
            {
                return NotFound(new { message = "RendezVous not found" });
            }

            try
            {
                _context.RendezVous.Remove(rendezVous);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Error deleting data.");
            }
        }
    }
}
