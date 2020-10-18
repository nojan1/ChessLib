using ChessLib.Constants;
using ChessLib.Pieces;
using ChessLib.State;

namespace ChessLib.Tests.Fixtures
{
    internal static class BoardSetupFixtures
    {
        internal static (BoardState boardState, PiecesState piecesState) GetInitialSetup()
        {
            var boardState = new BoardState();
            var piecesState = new PiecesState(new Piece[]{
                new Knight((1, 0), Colors.Black),
                new Knight((6, 0), Colors.Black),

                new Pawn((0,1), Colors.Black),
                new Pawn((1,1), Colors.Black),
                new Pawn((2,1), Colors.Black),
                new Pawn((3,1), Colors.Black),
                new Pawn((4,1), Colors.Black),
                new Pawn((5,1), Colors.Black),
                new Pawn((6,1), Colors.Black),

                new Pawn((0,6), Colors.White),
                new Pawn((1,6), Colors.White),
                new Pawn((2,6), Colors.White),
                new Pawn((3,6), Colors.White),
                new Pawn((4,6), Colors.White),
                new Pawn((5,6), Colors.White),
                new Pawn((6,6), Colors.White),

                new Knight((1, 7), Colors.White),
                new Knight((6, 7), Colors.White)
            });

            return (boardState, piecesState); 
        }
    }
}