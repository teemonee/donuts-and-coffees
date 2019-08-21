using System.Collections.Generic;
using DonutsCoffees.Api.Games;
using NUnit.Framework;

namespace DonutsCoffees.Api.Tests.GamesTests
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void ItSetsANewGameWithEmptyBoard()
        {
            Game game = new Game();
            Board board = new Board();
            game.Setup();
            Assert.AreEqual(board, game.board);
        }
    }
}