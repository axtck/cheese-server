using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database
{
    public class Square
    {
        public enum SquareLetterType
        {
            A, B, C, D, E, F, G, H
        }

        public enum SquareNumberType
        {
            One, Two, Three, Four, Five, Six, Seven, Eight
        }

        [Key]
        public Guid SquareId { get; set; }

        public SquareNumberType SquareNumber { get; set; }

        public SquareLetterType SquareLetter { get; set; }
    }
}
