using DonutsCoffees.Api.Controllers;
using NUnit.Framework;

namespace DonutsCoffees.Api.Tests.ControllersTests
{
    [TestFixture]
    public class GameControllerTest
    {
        [Test]
        public void GetNewGameSession_ItSendsNewGameSessionToClient()
        {
            var controller = new GameController();

            var result = controller.GetNewGameSession();
           
            Assert.IsNotNull(result);
        }
    }
}