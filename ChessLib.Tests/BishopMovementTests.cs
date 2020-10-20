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
    public class BishopMovementTests
    {
        [Fact]
        public void InitiallyBishopCantMoveAtAll()
        {
            (var boardState, var piecesState) = BoardSetupFixtures.GetInitialSetup();

            var bishop = new Bishop((2, 0), Colors.Black);

            boardState.GetAllPositions()
                .Any(((int x, int y) position) => bishop.CanMove(position, piecesState, boardState))
                .Should().BeFalse();
        }
    }
}
