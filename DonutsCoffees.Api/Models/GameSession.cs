using System.Collections.Generic;

namespace DonutsCoffees.Api.Models
{
    public class GameSession
    {
        public Board Board { get; set; }
        public GameType GameType { get; set; }
        public IPlayer PlayerOne { get; set; }
        public IPlayer PlayerTwo { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public GameStatus GameStatus { get; set; }
    }
}