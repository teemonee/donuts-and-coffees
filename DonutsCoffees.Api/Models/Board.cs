using System;
using System.Collections.Generic;
using System.Linq;

namespace DonutsCoffees.Api.Models
{
    public class Board
    {
        public List<object> spaces = new List<object> {1,2,3,4,5,6,7,8,9};

        public List<object> Spaces
        {
            get => spaces;

            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Spaces = spaces;
            }
        }
    }
}