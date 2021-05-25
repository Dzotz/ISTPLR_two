using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISTPLR_two;
using ISTPLR_two.Models;

namespace ISTPLR_two.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTeamPairsController : ControllerBase
    {
        private readonly ISTPLR_twoContext _context;

        public EventTeamPairsController(ISTPLR_twoContext context)
        {
            _context = context;
        }

        // GET: api/EventTeamPairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTeamPairs>>> GetEventTeamPairs()
        {
            return await _context.EventTeamPairs.ToListAsync();
        }

        // GET: api/EventTeamPairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTeamPairs>> GetEventTeamPairs(int id)
        {
            var eventTeamPairs = await _context.EventTeamPairs.FindAsync(id);

            if (eventTeamPairs == null)
            {
                return NotFound();
            }

            return eventTeamPairs;
        }
        [HttpGet("Teams/{id}")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams(int id)
        {
            var teams = await _context.EventTeamPairs.Where(etp => etp.EventId == id).Include(ptp => ptp.Team).Select(ptp => ptp.Team).Distinct().ToListAsync();


            if (teams == null)
            {
                return NotFound();
            }

            return teams;
        }
        // PUT: api/EventTeamPairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTeamPairs(int id, EventTeamPairs eventTeamPairs)
        {
            if (id != eventTeamPairs.EventTeamPairsId)
            {
                return BadRequest();
            }

            _context.Entry(eventTeamPairs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTeamPairsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventTeamPairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventTeamPairs>> PostEventTeamPairs(EventTeamPairs eventTeamPairs)
        {
            _context.EventTeamPairs.Add(eventTeamPairs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTeamPairs", new { id = eventTeamPairs.EventTeamPairsId }, eventTeamPairs);
        }

        // DELETE: api/EventTeamPairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTeamPairs(int id)
        {
            var eventTeamPairs = await _context.EventTeamPairs.FindAsync(id);
            if (eventTeamPairs == null)
            {
                return NotFound();
            }

            _context.EventTeamPairs.Remove(eventTeamPairs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventTeamPairsExists(int id)
        {
            return _context.EventTeamPairs.Any(e => e.EventTeamPairsId == id);
        }
    }
}
