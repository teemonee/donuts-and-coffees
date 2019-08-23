namespace DonutsCoffees.Api.Models
{
    public interface IPlayer
    {
        Token Token { get; set; }
        int SpaceSelection { get; set; }
    }
}