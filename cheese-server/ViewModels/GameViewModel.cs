using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheese_server.ViewModels
{
    public class GameViewModel
    {
        public Guid? GameId { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public string PGN { get; set; }

        public GameViewModel() { }

        public GameViewModel(Game game)
        {
            if (game == null)
            {
                return;
            }

            this.GameId = game.GameId;
            this.Name = game.Name;
            this.Time = game.Time;
            this.PGN = game.PGN;
        }

        public Game GetDatabaseModel()
        {
            return new Game()
            {
                GameId = this.GameId ?? Guid.NewGuid(),
                Name = this.Name,
                Time = DateTime.Now,
                PGN = this.PGN
            };
        }
    }
}
