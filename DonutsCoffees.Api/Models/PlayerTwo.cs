namespace DonutsCoffees.Api.Models
{
    public class PlayerTwo : IPlayer
    {
        public Token Token { get; set; }
        public int[] Moves { get; set; }
    }
}