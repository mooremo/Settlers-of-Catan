using NUnit.Framework;
using SettlersOfCatan;
using System.Collections;

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

            _controller.CurrentPlayer = _player1;
        }

        [Test]
        //The current player can trade with the bank
        public void TestThatTheCurrentPlayerCanTradeWithBank()
        {
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] {(int) CardType.Grain, (int) CardType.Grain, (int) CardType.Grain, (int) CardType.Grain});
            int cardTypeToTrade = (int) CardType.Grain;
            int cardTypeToGet = (int) CardType.Brick;
            bool result = _controller.TradeWithBank(cardTypeToTrade, cardTypeToGet);
            Assert.IsTrue(result);
        }

        [Test]
        //The current player cannot trade at a port if
        //the player does not have a settlement at the port
        public void TestThatTheCurrentPlayerCanNotTradeAtAPortIfNoSettlement()
        {
            int portNumber = _board.PortTiles.IndexOf((int)TileType.Port3);
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Grain, (int)CardType.Grain, (int)CardType.Grain });
            int cardTypeToTrade = (int)CardType.Grain;
            int cardTypeToGet = (int)CardType.Brick;
            bool result = _controller.TradeAtPort(portNumber, cardTypeToTrade, cardTypeToGet);
            Assert.IsFalse(result);
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 3 To 1 port
        public void TestThatTheCurrentPlayerCanTradeAtPort3To1()
        {
            int portNumber = _board.PortTiles.IndexOf((int) TileType.Port3);
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Grain, (int)CardType.Grain, (int)CardType.Grain });
            int cardTypeToTrade = (int)CardType.Grain;
            int cardTypeToGet = (int)CardType.Brick;
            bool result = _controller.TradeAtPort(portNumber, cardTypeToTrade, cardTypeToGet);
            Assert.IsTrue(result);
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 wool port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Wool()
        {
            int portNumber = _board.PortTiles.IndexOf((int)TileType.Port2Wool);
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Grain, (int)CardType.Grain});
            int cardTypeToTrade = (int)CardType.Grain;
            int cardTypeToGet = (int)CardType.Wool;
            bool result = _controller.TradeAtPort(portNumber, cardTypeToTrade, cardTypeToGet);
            Assert.IsTrue(result);
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 lumber port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Lumber()
        {
            int portNumber = _board.PortTiles.IndexOf((int)TileType.Port2Lumber);
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Grain, (int)CardType.Grain });
            int cardTypeToTrade = (int)CardType.Grain;
            int cardTypeToGet = (int)CardType.Lumber;
            bool result = _controller.TradeAtPort(portNumber, cardTypeToTrade, cardTypeToGet);
            Assert.IsTrue(result);
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 brick port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Brick()
        {
            int portNumber = _board.PortTiles.IndexOf((int)TileType.Port2Brick);
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Grain, (int)CardType.Grain });
            int cardTypeToTrade = (int)CardType.Grain;
            int cardTypeToGet = (int)CardType.Brick;
            bool result = _controller.TradeAtPort(portNumber, cardTypeToTrade, cardTypeToGet);
            Assert.IsTrue(result);
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 grain port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Grain()
        {
            int portNumber = _board.PortTiles.IndexOf((int)TileType.Port2Grain);
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Wool, (int)CardType.Wool });
            int cardTypeToTrade = (int)CardType.Wool;
            int cardTypeToGet = (int)CardType.Grain;
            bool result = _controller.TradeAtPort(portNumber, cardTypeToTrade, cardTypeToGet);
            Assert.IsTrue(result);
        }

        [Test]
        //The current player can trade at a port if
        //the player has a settlement adjacent to a 2 ore port
        public void TestThatTheCurrentPlayerCanTradeAtPort2Ore()
        {
            int portNumber = _board.PortTiles.IndexOf((int)TileType.Port2Ore);
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Grain, (int)CardType.Grain });
            int cardTypeToTrade = (int)CardType.Grain;
            int cardTypeToGet = (int)CardType.Ore;
            bool result = _controller.TradeAtPort(portNumber, cardTypeToTrade, cardTypeToGet);
            Assert.IsTrue(result);
        }

        [Test]
        //The current player can trade with another player
        //if they have the resource
        public void TestThatTheCurrentPlayerCanTradeWithAnotherPlayer()
        {
            _controller.CurrentPlayer.ResourceHand = new ArrayList(new int[] { (int)CardType.Grain, (int)CardType.Grain });
            int cardTypeToTrade = (int)CardType.Grain;
            int cardTypeToGet = (int)CardType.Wool;
            int numberToTrade = 2;
            int numberToGet = 2;
            bool result = _controller.TradeWithAnotherPlayer(1, cardTypeToTrade, numberToTrade, cardTypeToGet, numberToGet);
            Assert.IsTrue(result);
        }
    }
}
