using System;
using System.Collections.Generic;
using System.Linq;
using DonutsCoffees.Api.GameServices;
using DonutsCoffees.Api.Models;
 using NUnit.Framework;
 
 namespace DonutsCoffees.Api.Tests.GameServicesTests
 {
     [TestFixture]
     public class BoardTServiceTest
     {
         private Board _board;
         private Player _playerOne;
         private Player _playerTwo;
         private BoardService _boardService;

         [SetUp]
         public void Setup()
         {
             _board = new Board();
             _playerOne = new Player();
             _playerTwo = new Player();
         }
 
         [TearDown]
         public void TearDown()
         {
             _board = null;
         }
         
         [Test]
         public void GetMoves_ReturnsEmptyBoard()
         {
          
             _boardService = new BoardService(_board, _playerOne);
             var emptyBoard = _boardService.GetSpaces();
 
             var expected = new List<object> {1,2,3,4,5,6,7,8,9};
             Assert.AreEqual(expected, emptyBoard);
         }
         
         [Test]
         public void GetMoves_ReturnsBoardAfterOneMove()
         {
          
             _boardService = new BoardService(_board, _playerOne);
             _board.spaces[1] = Token.O;
             var updatedBoard = _boardService.GetSpaces();

             var expected = new List<object> {1,Token.O,3,4,5,6,7,8,9};
             Assert.AreEqual(expected, updatedBoard);
         }
         
         [Test]
         public void UpdateBoard_PlacesTokenAtGivenPosition()
         {
             _playerOne.Token = Token.O;
             _playerOne.RequestedCellPosition = 5;
             _boardService = new BoardService(_board, _playerOne);
             
             _boardService.UpdateBoard();
             
             var expected = new List<object> {1,2,3,4,Token.O,6,7,8,9};
             Assert.AreEqual(expected, _board.spaces);
         }

         [Test]
         public void GetAvailableSpaces_ReturnsListOfAvailableBoardMoves()
         {
             _playerOne.Token = Token.O;
             _playerOne.RequestedCellPosition = 5;
             _boardService = new BoardService(_board, _playerOne);
             _boardService.UpdateBoard();
             
             var updatedList = _boardService.GetAvailableSpaces();
             
             var expected = new List<object> {1,2,3,4,6,7,8,9};
             
             Assert.AreEqual(expected, updatedList);
         }
     }
 }