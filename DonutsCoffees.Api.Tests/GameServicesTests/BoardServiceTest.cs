using System;
using System.Collections.Generic;
using DonutsCoffees.Api.Models;
using NUnit.Framework;

namespace DonutsCoffees.Api.Tests.GameServicesTests
{
    [TestFixture]
    public class BoardTServiceTest
    {
        private Board _board;
        private Token _token;
        
        [SetUp]
        public void Setup()
        {
            _board = new Board();
        }

        [TearDown]
        public void TearDown()
        {
            _board = null;
        }
        
        [Test]
        public void UpdateBoard_PlacesTokenAtGivenPosition()
        {
            _token = Token.O;
            int position = 1;
            _board.UpdateBoard(_token, position);

            var expected = new List<object>();
            expected.Insert(1, _token);
            Console.Write(expected);
            Console.Write("here -__________");

            Assert.AreEqual(expected, _board.spaces);
        }
    }
}