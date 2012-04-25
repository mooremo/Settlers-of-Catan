using System.Collections;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    internal class TurnTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            GameController =
                new GameController(
                    new ArrayList(new[] {new Player("Bob"), new Player("Sue"), new Player("John"), new Player("Jill")}));
        }

        #endregion

        public GameController GameController;

        [Test]
        //When a player ends a turn the next player gets control
        public void TestThatCurrentPlayerUpdatesAtEndOfTurn()
        {
            GameController.CurrentPlayer = (Player) GameController.Players[0];
            GameController.CurrentPlayer.EndTurn();
            Assert.AreSame(GameController.Players[1], GameController.CurrentPlayer);
        }

        [Test]
        //When the last player, clockwise, ends a turn the first player gets control
        public void TestThatCurrentPlayerUpdatesAtEndOfTurnWhenPlayerIsLastInArray()
        {
            GameController.CurrentPlayer = (Player) GameController.Players[GameController.Players.Count - 1];
            GameController.CurrentPlayer.EndTurn();
            Assert.AreSame(GameController.Players[0], GameController.CurrentPlayer);
        }
    }
}