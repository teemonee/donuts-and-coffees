namespace DonutsCoffees.Api.Models
{
    public class Player : IPlayer
    {
        public Token Token { get; set; }
        public int[] Moves { get; set; }
        public int RequestedCellPosition { get; set; }
    }
}