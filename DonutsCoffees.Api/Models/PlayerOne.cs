namespace DonutsCoffees.Api.Models
{
    public class PlayerOne : IPlayer
    {
        public Token Token { get; set; }
        public int[] Moves { get; set; }
    }
}