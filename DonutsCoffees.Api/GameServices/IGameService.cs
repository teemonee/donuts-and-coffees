using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public interface IGameService
    { 
        GameSession SetupNewGame();
        void UpdateGameSession(Player player);
        void CheckIfGameOver();
    }
}