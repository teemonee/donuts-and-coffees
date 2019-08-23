namespace DonutsCoffees.Api.Models
{
    public interface IPlayer
    {
        Token Token { get; set; }
        int[] Moves { get; set; }
    }
}