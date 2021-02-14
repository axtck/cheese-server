using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Microsoft.AspNetCore.Cors;
using cheese_server.ViewModels;

namespace cheese_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly CheeseDbContext _context;

        public GamesController(CheeseDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> GetGames()
        {
            // get games
            List<Game> games = await _context.Games.ToListAsync();

            // initialize vmlist
            List<GameViewModel> gameViewModels = new List<GameViewModel>();

            foreach (var game in games)
            {
                // add games to vmlist
                gameViewModels.Add(new GameViewModel(game));
            }

            // return vms
            return gameViewModels;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameViewModel>> GetGame(Guid id)
        {
            // get games
            var game = await _context.Games.FindAsync(id);

            // check if game exists
            if (game == null)
            {
                return NotFound();
            }

            // return vm
            return new GameViewModel(await _context.Games
                .Where(g => g.GameId == id)
                .FirstOrDefaultAsync());
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(Guid id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameViewModel>> PostGame(GameViewModel gameViewModel)
        {
            // validate model
            if (!TryValidateModel(gameViewModel))
            {
                return BadRequest();
            }

            var game = gameViewModel.GetDatabaseModel(); // get dbmodel

            _context.Games.Add(game); // add game to context
            await _context.SaveChangesAsync(); // save changes

            return CreatedAtAction("GetGame", new { id = game.GameId }, new GameViewModel(game));
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(Guid id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
