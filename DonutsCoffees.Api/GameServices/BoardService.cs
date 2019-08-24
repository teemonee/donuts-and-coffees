using System;
using System.Collections.Generic;
using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public class BoardService
    {
        private static Board _board;
        private static Player _player;

        public BoardService(Board board, Player player)
        {
            _board = board;
            _player = player;
        }

        public List<object> GetSpaces()
        {
            return _board.spaces;
        }

        public void UpdateBoard()
        {
            _board.spaces[_player.RequestedCellPosition-1] = _player.Token;
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

        public bool IsValidMove()
        {
            return _board.spaces[_player.RequestedCellPosition - 1] is int;
        }
    }
}