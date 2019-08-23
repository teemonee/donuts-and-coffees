using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public interface IGameService
    {
        GameSession StartNewGame(GameSession gameSession);
        void UpdateGameSession(GameSession gameSession);
        void CheckIfGameOver(GameSession gameSession);
    }
}