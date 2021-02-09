using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database
{
    public class Piece
    {
        public enum PieceType
        {
            King,
            Queen,
            Rook,
            Knight,
            Bishop,
            Pawn
        }

        public enum ColorType
        {
            Black,
            White
        }

        [Key]
        public Guid PieceId { get; set; }


        public PieceType BoardPiece { get; set; }
        public ColorType BoardColor { get; set; }
    }
}
