using System;
using NUnit.Framework;
using DonutsCoffees.Api.Games;

namespace DonutsCoffees.Api.Tests.GamesTests
{
    public class BoardTest
    {
        public void ItDisplaysEmptyBoard()
        {
            Board board = new Board(9);
            Console.WriteLine(board);
            Assert.AreEqual(board, board);
        }
    }
}
