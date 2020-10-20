using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChessLib.Pieces;

namespace ChessLib.State
{
    public interface IBoardState
    {
        bool IsOnBoard((int x, int y) position);
        IEnumerable<(int x, int y)> GetAllPositions();
    }
}