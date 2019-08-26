using System.Collections.Generic;

namespace DonutsCoffees.Api.Models
{
    public class GameSession
    {
        public Board Board { get; set; }
        public Player PlayerOne { get; set; }
    }
}