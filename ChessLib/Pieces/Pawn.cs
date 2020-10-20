using System.Linq;
using ChessLib.State;
using ChessLib.Util;

namespace ChessLib.Pieces
{
    public class Pawn : Piece
    {
        public Pawn((int x, int y) position, string color) : base(position, color)
        {
        }

        public override bool CanMove((int x, int y) to, PiecesState piecesState, IBoardState boardState)
        {
            //TODO: Support the case where there might be of axis players

            var possiblePositions = FluentList.Create<(int x, int y)>()
                .With((Position.x + DefaultMoveDirection.deltaX, Position.y + DefaultMoveDirection.deltaY))
                .WithIf((Position.x + DefaultMoveDirection.deltaX + 1, Position.y + DefaultMoveDirection.deltaY), p => piecesState.IsOccupiedByOtherColor(p,  Color))
                .WithIf((Position.x + DefaultMoveDirection.deltaX - 1, Position.y + DefaultMoveDirection.deltaY), p => piecesState.IsOccupiedByOtherColor(p,  Color))
                .Where(p => boardState.IsOnBoard(p) && !piecesState.IsOccupiedBy(p, Color));

            return possiblePositions.Contains(to);
        }
    }
}