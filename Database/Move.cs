using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database
{
    [Table("Moves")]
    public class Move
    {
        [Key]
        public Guid MoveId { get; set; }

        [Required]
        public Piece Piece { get; set; }

        public Square StartSquare { get; set; }

        public Square EndSquare { get; set; }

        [Required]
        public bool Check { get; set; }

        [Required]
        public bool Take { get; set; }

        [Required]
        public Guid GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
    }
}
