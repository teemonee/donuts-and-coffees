namespace DonutsCoffees.Api.Models
{
    public interface IPlayer
    {
        string Token { get; set; }
//        int[] Moves { get; set; }
        int RequestedCellPosition { get; set; }
    }
}