using System.Collections.Generic;
using DonutsCoffees.Api.GameServices;
using DonutsCoffees.Api.Models;
 using NUnit.Framework;
 
 namespace DonutsCoffees.Api.Tests.GameServicesTests
 {
     [TestFixture]
     public class BoardTServiceTest
     {
         private Board _board;
         private Player _player;
         private BoardService _boardService;

         [SetUp]
         public void Setup()
         {
             _board = new Board();
             _player= new Player();
         }
 
         [TearDown]
         public void TearDown()
         {
             _board = null;
         }

         private void UpdatePlayer()
         {
             _player.Token = Token.O.ToString();
             _player.RequestedCellPosition = 5;
         }
         
         [Test]
         public void GetSpaces_ReturnsEmptyBoardAtGameStart()
         {
          
             _boardService = new BoardService(_board);
             var emptyBoard = _boardService.GetSpaces();
 
             var expected = new List<object> {1,2,3,4,5,6,7,8,9};
             Assert.AreEqual(expected, emptyBoard);
         }
         
         [Test]
         public void GetSpaces_ReturnsUpdatedBoardAfterOneMove()
         {
             var token = Token.O.ToString();
             _boardService = new BoardService(_board);
             _board.spaces[1] = token;
             var updatedBoard = _boardService.GetSpaces();

             var expected = new List<object> {1,token,3,4,5,6,7,8,9};
             Assert.AreEqual(expected, updatedBoard);
         }
         
         [Test]
         public void UpdateBoard_PlacesTokenAtGivenPosition()
         {
             var token = Token.O.ToString();
             UpdatePlayer();
             _boardService = new BoardService(_board);
             
             _boardService.UpdateBoard(_player.RequestedCellPosition, _player.Token);
             
             var expected = new List<object> {1,2,3,4,token,6,7,8,9};
             Assert.AreEqual(expected, _board.spaces);
         }

         [Test]
         public void GetAvailableMoves_ReturnsListOfAvailableBoardMoves()
         {
             UpdatePlayer();
             _boardService = new BoardService(_board);
             _boardService.UpdateBoard(_player.RequestedCellPosition, _player.Token);
             
             var updatedList = _boardService.GetAvailableMoves();
             
             var expected = new List<object> {1,2,3,4,6,7,8,9};
             
             Assert.AreEqual(expected, updatedList);
         }

         [Test]
         public void IsValidMove_ReturnsTrueIfSpaceIsAvailable()
         {
             UpdatePlayer();
             _boardService = new BoardService(_board);
             _boardService.UpdateBoard(_player.RequestedCellPosition, _player.Token);
             
             _player.RequestedCellPosition = 3;

             Assert.That(_boardService.IsValidMove(_player.RequestedCellPosition));
         }
         
         [Test]
         public void IsValidMove_ReturnsFalseIfSpaceIsUnavailable()
         {
             UpdatePlayer();
             _boardService = new BoardService(_board);
             _boardService.UpdateBoard(_player.RequestedCellPosition, _player.Token);
             
             _player.RequestedCellPosition = 5;

             Assert.False(_boardService.IsValidMove(_player.RequestedCellPosition));
         }
     }
 }