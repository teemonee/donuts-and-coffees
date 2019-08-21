namespace DonutsCoffees.Api.Games
{
    public class Game
    {
        public Board board;

        public void Setup()
        {
            board = new Board();
        }
    }
}