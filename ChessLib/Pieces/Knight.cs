using System.Linq;
using ChessLib.State;
using ChessLib.Util;

namespace ChessLib.Pieces
{
    public class Knight : Piece
    {
        public Knight((int x, int y) position, string color) : base(position, color)
        {
        }

        public override bool CanMove((int x, int y) to, PiecesState piecesState, BoardState boardState)
        {
            var positions = FluentList.Create<(int x, int y)>()
                .With((Position.x - 1 ,Position.y - 2))
                .With((Position.x + 1,Position.y - 2))
                .With((Position.x + 2,Position.y - 1))
                .With((Position.x + 2,Position.y + 1))
                .With((Position.x + 1,Position.y + 2))
                .With((Position.x - 1,Position.y + 2))
                .With((Position.x + 1,Position.y + 2))
                .With((Position.x - 2,Position.y + 1))
                .With((Position.x - 2,Position.y - 1))
                .Where(p => 
                    boardState.IsOnBoard(p) && !piecesState.IsOccupiedBy(p, Color)
                );

            return positions.Contains(to);
        }
    }
}