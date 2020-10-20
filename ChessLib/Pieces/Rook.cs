using System.Linq;
using ChessLib.State;
using ChessLib.Util;

namespace ChessLib.Pieces
{
    public class Rook : LinnearMovingPiece
    {
        public Rook((int x, int y) position, string color) 
            : base(position, color, LinnearMovement.Straight)
        {
        }
    }
}