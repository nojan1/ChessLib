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

        [Theory]
        [InlineData(3,3, false)]
        [InlineData(4,3, true)]
        [InlineData(5,3, false)]
        [InlineData(3,4, true)]
        [InlineData(4,4, false)]
        [InlineData(5,4, true)]
        [InlineData(3,5, false)]
        [InlineData(4,5, true)]
        [InlineData(5,5, false)]
        public void CanMoveCorrectlyOnEmptyBoard(int x, int y, bool isValid)
        {
            (var boardState, var piecesState) = BoardSetupFixtures.GetEmpty();

            var rook = new Rook((4, 4), Colors.Black);
            rook.CanMove((x,y), piecesState, boardState).Should().Be(isValid);
        }
    }
}
