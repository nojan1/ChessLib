using System;
using System.Linq;
using ChessLib.State;
using ChessLib.Util;

namespace ChessLib.Pieces
{
    [Flags]
    public enum LinnearMovement
    {
        Straight,
        Diagonal
    }

    public abstract class LinnearMovingPiece : Piece
    {
        private readonly LinnearMovement linnearMovement;

        protected LinnearMovingPiece((int x, int y) position, string color, LinnearMovement linnearMovement) : base(position, color)
        {
            this.linnearMovement = linnearMovement;
        }

        public override bool CanMove((int x, int y) to, PiecesState piecesState, IBoardState boardState)
        {
            Func<(int x, int y), WhilePredicateResult> checkPosition = ((int x, int y) position) =>
            {
                if(piecesState.IsOccupiedByOtherColor(position, Color))
                    return WhilePredicateResult.IncludeAndStop;

                if(piecesState.IsOccupiedBy(position, Color) || !boardState.IsOnBoard(position))
                    return WhilePredicateResult.Stop;

                return WhilePredicateResult.Include;
            };

            var positions = FluentList.Create<(int x, int y)>();

            if (linnearMovement.HasFlag(LinnearMovement.Diagonal))
            {
                positions.WithWhile(
                    (Position.x - 1, Position.y - 1), 
                    ((int x, int y) lastPosition) => (lastPosition.x - 1, lastPosition.y - 1),
                    checkPosition
                );

                positions.WithWhile(
                    (Position.x - 1, Position.y + 1), 
                    ((int x, int y) lastPosition) => (lastPosition.x - 1, lastPosition.y + 1),
                    checkPosition
                );

                positions.WithWhile(
                    (Position.x + 1, Position.y + 1), 
                    ((int x, int y) lastPosition) => (lastPosition.x + 1, lastPosition.y + 1),
                    checkPosition
                );

                positions.WithWhile(
                    (Position.x + 1, Position.y - 1), 
                    ((int x, int y) lastPosition) => (lastPosition.x + 1, lastPosition.y - 1),
                    checkPosition
                );
            }

            if (linnearMovement.HasFlag(LinnearMovement.Straight))
            {
                positions.WithWhile(
                    (Position.x, Position.y - 1), 
                    ((int x, int y) lastPosition) => (lastPosition.x, lastPosition.y - 1),
                    checkPosition
                );

                positions.WithWhile(
                    (Position.x, Position.y + 1), 
                    ((int x, int y) lastPosition) => (lastPosition.x, lastPosition.y + 1),
                    checkPosition
                );

                positions.WithWhile(
                    (Position.x + 1, Position.y), 
                    ((int x, int y) lastPosition) => (lastPosition.x + 1, lastPosition.y),
                    checkPosition
                );

                positions.WithWhile(
                    (Position.x - 1, Position.y), 
                    ((int x, int y) lastPosition) => (lastPosition.x - 1, lastPosition.y),
                    checkPosition
                );
            }

            return positions.Contains(to);
        }
    }
}