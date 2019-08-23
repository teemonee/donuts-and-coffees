using System.Collections.Generic;

namespace DonutsCoffees.Api.Models
{
    public class Board
    {
        private List<object> spaces = new List<object>(9);

        public List<object> Spaces
        {
            get => spaces;
            set => spaces = value;
        }
    }
}