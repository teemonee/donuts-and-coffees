namespace DonutsCoffees.Api.Models
{
    public class Player : IPlayer
    {
        public Token Token { get; set; }
        public int SpaceSelection { get; set; }
    }
}