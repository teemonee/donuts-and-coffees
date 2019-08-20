using System;
using NUnit.Framework;

namespace DonutsCoffees.Api.Tests.GamesTests
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void ItReturnsEmptyBoard()
        {
          Board board = new Board();
          AssertThat(board.empty == null);
        }
    }
}
