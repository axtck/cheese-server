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

        [Required]
        public string PGN { get; set; }
    }
}
