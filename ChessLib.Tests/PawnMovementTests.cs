using System;
using ChessLib.Pieces;
using Xunit;
using FluentAssertions;
using ChessLib.State;
using ChessLib.Constants;
using ChessLib.Tests.Fixtures;

namespace ChessLib.Tests
{
    public class PawnMovementTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(0, 1)]
        [InlineData(2, 1)]
        [InlineData(0, 2)]
        [InlineData(2, 2)]
        public void PawnCanNotInitallyMoveTo(int toX, int toY)
        {
            (var boardState, var piecesState) = BoardSetupFixtures.GetInitialSetup();

            var knight = new Pawn((1, 1), Colors.Black);
            knight.CanMove((toX, toY), piecesState, boardState).Should().BeFalse();
        }
    }
}
