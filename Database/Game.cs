using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }

        [MaxLength(40), Required]
        public string Name { get; set; }

        public List<Move> Moves { get; set; }

        [Required]
        public Guid PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
    }
}
