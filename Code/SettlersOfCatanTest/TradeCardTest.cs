using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    class TradeCardTest
    {
        private GameController _controller;
        private Board _board;
        private Player _player1;
        private Player _player2;
        private Player _player3;
        private Player _player4;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();

            _player1 = new Player();
            _player2 = new Player();
            _player3 = new Player();
            _player4 = new Player();

            _controller = new GameController();
            _controller.Board = _board;

            _controller.Players.Add(_player1);
            _controller.Players.Add(_player2);
            _controller.Players.Add(_player3);
            _controller.Players.Add(_player4);
        }

        [Test]
        //The current player can trade with the bank
        public void TestThatTheCurrentPlayerCanTradeWithBank()
        {
            
        }

        [Test]
        //A non current player should not be able to trade with bank
        public void TestThatANonCurrentPlayerCannotTradeWithBank()
        {
            
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 3 To 1 port
        public void TestThatTheCurrentPlayerCanTradeAtPort3To1()
        {
            
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 wool port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Wool()
        {

        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 lumber port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Lumber()
        {

        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 brick port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Brick()
        {

        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 grain port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Grain()
        {

        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 ore port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Ore()
        {

        }

        [Test]
        //If a player has a settlement at a port
        //and they are not the current player then no trade
        public void TestThatANonCurrentPlayerCanNotTradeAtPort()
        {
            
        }
    }
}
