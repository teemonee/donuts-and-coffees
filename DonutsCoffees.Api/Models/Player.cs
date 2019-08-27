namespace DonutsCoffees.Api.Models
{
    public class Player : IPlayer
    {
        public string Token { get; set; }
        public int RequestedCellPosition { get; set; }
    }
}