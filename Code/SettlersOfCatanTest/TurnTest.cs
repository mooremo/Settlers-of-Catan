using System.Collections;
using System.Collections.Generic;
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

        #endregion

        private GameController _controller;
        private Board _board;
        private Player _player1;
        private Player _player2;
        private Player _player3;
        private Player _player4;

        [Test]
        //When a city is adjacent to a hex without the number rolled
        //the player receives 0 resource cards
        public void TestThatAPlayerDoesNotReceiveAResourceForACityNextToHexWithoutNumberRolled()
        {
            var tempTile = (Tile) _board.TerrainTiles[0];
            _controller.Dice.Value = (tempTile.Number < 12) ? tempTile.Number + 1 : tempTile.Number - 1;
            ((Vertex) tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.City);
            int countBefore = ((Player) _controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore, countAfter);
        }

        [Test]
        //When a village is adjacent to a hex without the number rolled
        //the player receives 0 resource cards
        public void TestThatAPlayerDoesNotReceiveAResourceForAVillageNextToHexWithoutNumberRolled()
        {
            var tempTile = (Tile) _board.TerrainTiles[0];
            _controller.Dice.Value = (tempTile.Number < 12) ? tempTile.Number + 1 : tempTile.Number - 1;
            ((Vertex) tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.Village);
            int countBefore = ((Player) _controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore, countAfter);
        }

        [Test]
        //When a village is adjacent to a hex with the number rolled
        //the player receives 1 resource card
        public void TestThatAPlayerReceivesOneResourceForAVillageNextToHexWithNumberRolled()
        {
            var tempTile = (Tile) _board.TerrainTiles[0];
            _controller.Dice.Value = tempTile.Number;
            ((Vertex) tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.Village);
            int countBefore = ((Player) _controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        [Test]
        //When a city is adjacent to a hex with the number rolled
        //the player receives 2 resource card
        public void TestThatAPlayerReceivesTwoResourceForACityNextToHexWithNumberRolled()
        {
            var tempTile = (Tile) _board.TerrainTiles[0];
            _controller.Dice.Value = tempTile.Number;
            ((Vertex) tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.City);
            int countBefore = ((Player) _controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore + 2, countAfter);
        }

        [Test]
        //When two cities are adjacent to a hex with the number rolled
        //the player receives 4 resource card
        public void TestThatAPlayerReceivesFourResourcesForTwoCitiesNextToHexWithNumberRolled()
        {
            var tempTile = (Tile) _board.TerrainTiles[0];
            _controller.Dice.Value = tempTile.Number;
            ((Vertex) tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.City);
            ((Vertex) tempTile.Vertices[2]).Settlement = new Settlement(_player1, SettlementType.City);
            int countBefore = ((Player) _controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore + 4, countAfter);
        }

        [Test]
        //When 2 villages is adjacent to a hex with the number rolled
        //the player receives 2 resource card
        public void TestThatAPlayerReceivesTwoResourcesForVillagesNextToHexWithNumberRolled()
        {
            var tempTile = (Tile) _board.TerrainTiles[0];
            _controller.Dice.Value = tempTile.Number;
            ((Vertex) tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.Village);
            ((Vertex) tempTile.Vertices[2]).Settlement = new Settlement(_player1, SettlementType.Village);
            int countBefore = ((Player) _controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore + 2, countAfter);
        }

        [Test]
        //When a player ends a turn the next player gets control
        public void TestThatCurrentPlayerUpdatesAtEndOfTurn()
        {
            _controller.CurrentPlayer = (Player) _controller.Players[0];
            _controller.ChangeCurrentPlayer();
            Assert.AreSame(_controller.Players[1], _controller.CurrentPlayer);
        }

        [Test]
        //When the last player, clockwise, ends a turn the first player gets control
        public void TestThatCurrentPlayerUpdatesAtEndOfTurnWhenPlayerIsLastInArray()
        {
            _controller.CurrentPlayer = (Player) _controller.Players[_controller.Players.Count - 1];
            _controller.ChangeCurrentPlayer();
            Assert.AreSame(_controller.Players[0], _controller.CurrentPlayer);
        }

        [Test]
        //Tests the dice returns a number
        public void TestThatDiceRolls()
        {
            Assert.IsNotNull(_controller.Dice.Roll());
        }

        [Test]
        //When the dice roll a number between 2 and 12 is returned
        public void TestThatTheDiceReturnANumberBetween2And12()
        {
            int actual = _controller.Dice.Roll();
            Assert.Greater(actual, 2);
            Assert.Less(actual, 13);
        }

        [Test]
        //When a 7 is rolled a player with 10 cards loses 5
        public void TestThatWhenA7IsRolledAPlayerWith10CardsLoses5()
        {
            var resources = new List<CardType>(new CardType[] { CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore });
            ((Player) _controller.Players[0]).ResourceHand = resources;
            _controller.DiscardForMoreThanSeven();
            int count = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(5, count);
        }

        [Test]
        //When a 7 is rolled a player with 6 cards loses 0
        public void TestThatWhenA7IsRolledAPlayerWith6CardsLoses0()
        {
            var resources = new List<CardType>(new CardType[] { CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore });
            ((Player) _controller.Players[0]).ResourceHand = resources;
            _controller.DiscardForMoreThanSeven();
            int count = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(6, count);
        }

        [Test]
        //When a 7 is rolled a player with 7 cards loses 3
        public void TestThatWhenA7IsRolledAPlayerWith7CardsLoses3()
        {
            var resources = new List<CardType>(new CardType[] { CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore, CardType.Ore });
            ((Player) _controller.Players[0]).ResourceHand = resources;
            _controller.DiscardForMoreThanSeven();
            int count = ((Player) _controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(4, count);
        }








        [Test]
        //When a village is adjacent to a hex with the number rolled but the robber is there
        //the player receives 0 resource cards
        public void TestThatAPlayerReceivesZeroResourceForAVillageNextToHexWithNumberRolledAndRobberPresent()
        {
            var tempTile = (Tile)_board.TerrainTiles[0];
            tempTile.Robber = true;
            _controller.Dice.Value = tempTile.Number;
            ((Vertex)tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.Village);
            int countBefore = ((Player)_controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player)_controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore, countAfter);
        }

        [Test]
        //When a city is adjacent to a hex with the number rolled but the robber is there
        //the player receives 0 resource cards
        public void TestThatAPlayerReceivesZeroResourceForACityNextToHexWithNumberRolledAndRobberPresent()
        {
            var tempTile = (Tile)_board.TerrainTiles[0];
            tempTile.Robber = true;
            _controller.Dice.Value = tempTile.Number;
            ((Vertex)tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.City);
            int countBefore = ((Player)_controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player)_controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore, countAfter);
        }

        [Test]
        //When two cities are adjacent to a hex with the number rolled but the robber is there
        //the player receives 0 resource card
        public void TestThatAPlayerReceivesZeroResourcesForTwoCitiesNextToHexWithNumberRolledAndRobberPresent()
        {
            var tempTile = (Tile)_board.TerrainTiles[0];
            tempTile.Robber = true;
            _controller.Dice.Value = tempTile.Number;
            ((Vertex)tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.City);
            ((Vertex)tempTile.Vertices[2]).Settlement = new Settlement(_player1, SettlementType.City);
            int countBefore = ((Player)_controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player)_controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore, countAfter);
        }

        [Test]
        //When 2 villages is adjacent to a hex with the number rolled but the robber is there
        //the player receives 0 resource card
        public void TestThatAPlayerReceivesZeroResourcesForVillagesNextToHexWithNumberRolledAndRobberPresent()
        {
            var tempTile = (Tile)_board.TerrainTiles[0];
            tempTile.Robber = true;
            _controller.Dice.Value = tempTile.Number;
            ((Vertex)tempTile.Vertices[0]).Settlement = new Settlement(_player1, SettlementType.Village);
            ((Vertex)tempTile.Vertices[2]).Settlement = new Settlement(_player1, SettlementType.Village);
            int countBefore = ((Player)_controller.Players[0]).ResourceHand.Count;
            _controller.AwardResourceForSettlementAdjacentToRolledHex();
            int countAfter = ((Player)_controller.Players[0]).ResourceHand.Count;
            Assert.AreEqual(countBefore, countAfter);
        }

    }
}