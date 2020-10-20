using System;
using ChessLib.Pieces;
using Xunit;
using FluentAssertions;
using ChessLib.State;
using ChessLib.Constants;
using ChessLib.Tests.Fixtures;
using System.Linq;

namespace ChessLib.Tests
{
    public class RookMovementTests
    {
        [Fact]
        public void InitiallyRookCantMoveAtAll()
        {
            (var boardState, var piecesState) = BoardSetupFixtures.GetInitialSetup();

            var rook = new Rook((0, 0), Colors.Black);

            boardState.GetAllPositions()
                .Any(((int x, int y) position) => rook.CanMove(position, piecesState, boardState))
                .Should().BeFalse();
        }
    }
}
