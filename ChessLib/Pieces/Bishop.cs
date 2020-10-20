using System.Linq;
using ChessLib.State;
using ChessLib.Util;

namespace ChessLib.Pieces
{
    public class Bishop : LinnearMovingPiece
    {
        public Bishop((int x, int y) position, string color) 
            : base(position, color, LinnearMovement.Diagonal)
        {
        }
    }
}