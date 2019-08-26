using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public interface IGameService
    {
        GameSession SetupNewGame();
        void UpdateGameSession();
        void CheckIfGameOver();
    }
}