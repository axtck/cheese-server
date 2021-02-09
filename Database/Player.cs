using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database
{
    [Table("Players")]
    public class Player
    {
        public enum ColorType
        {
            Black, White
        }

        [Key]
        public Guid PlayerId { get; set; }

        [MaxLength(40), Required]
        public string Name { get; set; }

        [MaxLength(4), Required]
        public int Rating { get; set; }

        [Required]
        public ColorType Color { get; set; }

        public List<Game> Games { get; set; }
    }
}
