using System;
using System.Collections.Generic;
using NUnit.Framework;
using DonutsCoffees.Api.Games;

namespace DonutsCoffees.Api.Tests.GamesTests
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void ItReturnsEmptyBoard()
        {    
            
            Board board = new Board();
            var expectedList = new List<int>();
            Assert.AreEqual(expectedList,board.Spaces);
        }
    }
}
