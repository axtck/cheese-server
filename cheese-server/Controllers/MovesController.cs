using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;

namespace cheese_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        private readonly CheeseDbContext _context;

        public MovesController(CheeseDbContext context)
        {
            _context = context;
        }

        // GET: api/Moves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Move>>> GetMoves()
        {
            return await _context.Moves.ToListAsync();
        }

        // GET: api/Moves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Move>> GetMove(Guid id)
        {
            var move = await _context.Moves.FindAsync(id);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }

        // PUT: api/Moves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMove(Guid id, Move move)
        {
            if (id != move.MoveId)
            {
                return BadRequest();
            }

            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
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

        // POST: api/Moves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Move>> PostMove(Move move)
        {
            _context.Moves.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = move.MoveId }, move);
        }

        // DELETE: api/Moves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Move>> DeleteMove(Guid id)
        {
            var move = await _context.Moves.FindAsync(id);
            if (move == null)
            {
                return NotFound();
            }

            _context.Moves.Remove(move);
            await _context.SaveChangesAsync();

            return move;
        }

        private bool MoveExists(Guid id)
        {
            return _context.Moves.Any(e => e.MoveId == id);
        }
    }
}
