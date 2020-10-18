using System;
using ChessLib.Pieces;
using Xunit;
using FluentAssertions;
using ChessLib.State;
using ChessLib.Constants;
using ChessLib.Tests.Fixtures;

namespace ChessLib.Tests
{
    public class KnightMovementTests
    {
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(1, 0)]
        [InlineData(-1, 1)]
        [InlineData(3, 1)]
        public void KnightCanNotInitallyMoveTo(int toX, int toY)
        {
            (var boardState, var piecesState) = BoardSetupFixtures.GetInitialSetup();

            var knight = new Knight((1, 0), Colors.Black);
            knight.CanMove((toX, toY), piecesState, boardState).Should().BeFalse();
        }
    }
}
