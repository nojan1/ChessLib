using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChessLib.Pieces;

namespace ChessLib.State
{
    public class BoardState : IBoardState
    {
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }

        public BoardState(int boardWidth = 8, int boardHeight = 8)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
        }

        public bool IsOnBoard((int x, int y) position) =>
            position.x > 0 &&
            position.y > 0 &&
            position.x < BoardWidth - 1 &&
            position.y < BoardHeight - 1;

        public IEnumerable<(int x, int y)> GetAllPositions()
        {
            for (int y = 0; y < BoardHeight; y++)
                for (int x = 0; x < BoardWidth; x++)
                    yield return (x, y);
        }
    }
}