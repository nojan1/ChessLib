using System;
using ChessLib.Constants;
using ChessLib.State;

namespace ChessLib.Pieces
{
    public abstract class Piece
    {
        public string Color { get; private set; }
        public (int x, int y) Position { get; protected set; }

        private (int deltaX, int deltaY)? defaultMoveDirection;
        public (int deltaX, int deltaY) DefaultMoveDirection {
            get {
                if(defaultMoveDirection != null)
                    return defaultMoveDirection.Value;

                if(Color == Colors.Black)
                    return (0, 1);
                else if(Color == Colors.White)
                    return (0, -1);
                else
                    throw new Exception("Standard 2 player colors are not used, please set DefaultMoveDirection manually");
            }

            set {
                defaultMoveDirection = value;
            }
        }

        public Piece((int x, int y) position, string color)
        {
            Position = position;
            Color = color;
        }

        public abstract bool CanMove((int x, int y) to, PiecesState piecesState, BoardState boardState);
    }
}