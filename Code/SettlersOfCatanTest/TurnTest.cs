using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    class TurnTest
    {
        public GameController GameController;
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            GameController = new GameController(new ArrayList(new Player[] {new Player("Bob"), new Player("Sue"), new Player("John"), new Player("Jill")}));
        }

        #endregion

        [Test]
        //When a player ends a turn that the next player gets control
        public void TestThatCurrentPlayerUpdatesAtEndOfTurn()
        {
            GameController.CurrentPlayer = (Player)GameController.Players[0];
            GameController.CurrentPlayer.EndTurn();
            Assert.AreSame((Player)GameController.Players[1], GameController.CurrentPlayer);
        }

        [Test]
        //When a the last player, clockwise, ends a turn that the first player gets control
        public void TestThatCurrentPlayerUpdatesAtEndOfTurnWhenPlayerIsLastInArray()
        {
            GameController.CurrentPlayer = (Player)GameController.Players[GameController.Players.Count-1];
            GameController.CurrentPlayer.EndTurn();
            Assert.AreSame((Player)GameController.Players[0], GameController.CurrentPlayer);
        }
    }
}
