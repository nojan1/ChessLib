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
    public class QueenMovementTests
    {
        [Fact]
        public void InitiallyQueenCantMoveAtAll()
        {
            (var boardState, var piecesState) = BoardSetupFixtures.GetInitialSetup();

            var queen = new Queen((4, 0), Colors.Black);

            boardState.GetAllPositions()
                .Any(((int x, int y) position) => queen.CanMove(position, piecesState, boardState))
                .Should().BeFalse();
        }
    }
}
