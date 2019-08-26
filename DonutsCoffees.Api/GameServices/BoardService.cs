using System;
using System.Collections.Generic;
using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public class BoardService
    {
        private static Board _board;

        public BoardService(Board board)
        {
            _board = board;
        }

        public List<object> GetSpaces()
        {
            return _board.spaces;
        }

        public void UpdateBoard(int requestedCellPosition, string token)
        {
            _board.spaces[requestedCellPosition-1] = token;
        }

        public List<object> GetAvailableMoves()
        {
            var availableList = new List<object>();
            for (var i = 0; i  < _board.spaces.Count; i ++)
            {
                if (_board.spaces[i] is int)
                {
                    availableList.Add(i+1);
                }
            }
            return availableList;
        }

        public bool IsValidMove(int requestedCellPosition)
        {
            return _board.spaces[requestedCellPosition - 1] is int;
        }
    }
}