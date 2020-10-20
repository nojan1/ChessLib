using System.Linq;
using ChessLib.State;
using ChessLib.Util;

namespace ChessLib.Pieces
{
    public class Queen : LinnearMovingPiece
    {
        public Queen((int x, int y) position, string color) 
            : base(position, color, LinnearMovement.Diagonal | LinnearMovement.Straight)
        {
        }
    }
}