using System.Collections.Generic;
using System.Linq;

namespace DonutsCoffees.Api.Games
{
    public class Board
    {
        public int[] spaces;
        public Board(int boardSize)
        {
            spaces = Enumerable.Range(0, boardSize).ToArray();
        }

        //public static List<object> CreateBoard(int cellCount)
        //{
        //    var boardList = new List<object>(cellCount);
        //    boardList.Add(cellCount);
        //    return boardList;
        //}

        public int[] GetSpaces()
        {
            return spaces;
        }
    }
}
