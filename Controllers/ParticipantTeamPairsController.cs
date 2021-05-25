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
    public class ParticipantTeamPairsController : ControllerBase
    {
        private readonly ISTPLR_twoContext _context;

        public ParticipantTeamPairsController(ISTPLR_twoContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantTeamPairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantTeamPairs>>> GetParticipantTeamPairs()
        {
            return await _context.ParticipantTeamPairs.ToListAsync();
        }

        // GET: api/ParticipantTeamPairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantTeamPairs>> GetParticipantTeamPairs(int id)
        {
            var participantTeamPairs = await _context.ParticipantTeamPairs.FindAsync(id);

            if (participantTeamPairs == null)
            {
                return NotFound();
            }

            return participantTeamPairs;
        }


        [HttpGet("Participants/{id}")]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants(int id)
        {
             var participants = await  _context.ParticipantTeamPairs.Where(ptp => ptp.TeamId == id).Include(ptp => ptp.Participant).Select(ptp=>ptp.Participant).Distinct().ToListAsync();
           

            if (participants == null)
            {
                return NotFound();
            }

            return participants;
        }


    // PUT: api/ParticipantTeamPairs/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantTeamPairs(int id, ParticipantTeamPairs participantTeamPairs)
        {
            if (id != participantTeamPairs.ParticipantTeamPairsId)
            {
                return BadRequest();
            }

            _context.Entry(participantTeamPairs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantTeamPairsExists(id))
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

        // POST: api/ParticipantTeamPairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParticipantTeamPairs>> PostParticipantTeamPairs(ParticipantTeamPairs participantTeamPairs)
        {
            _context.ParticipantTeamPairs.Add(participantTeamPairs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantTeamPairs", new { id = participantTeamPairs.ParticipantTeamPairsId }, participantTeamPairs);
        }

        // DELETE: api/ParticipantTeamPairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantTeamPairs(int id)
        {
            var participantTeamPairs = await _context.ParticipantTeamPairs.FindAsync(id);
            if (participantTeamPairs == null)
            {
                return NotFound();
            }

            _context.ParticipantTeamPairs.Remove(participantTeamPairs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantTeamPairsExists(int id)
        {
            return _context.ParticipantTeamPairs.Any(e => e.ParticipantTeamPairsId == id);
        }
    }
}
