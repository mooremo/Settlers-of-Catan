using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    internal class DrawCardTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _controller = new GameController();
        }

        #endregion

        private GameController _controller;

        [Test]
        public void TestDevelopmentDeckInitializesWithCorrectNumberOfKnights()
        {
            int knightCount = 0;
            foreach (CardType card in _controller.DevelopmentDeck)
            {
                if (card == CardType.Solider)
                {
                    knightCount++;
                }
            }

            Assert.AreEqual(14, knightCount);
        }

        [Test]
        public void TestDevelopmentDeckInitializesWithCorrectNumberOfMonopoly()
        {
            int monopolyCount = 0;
            foreach (CardType card in _controller.DevelopmentDeck)
            {
                if (card == CardType.Monopoly)
                {
                    monopolyCount++;
                }
            }

            Assert.AreEqual(2, monopolyCount);
        }

        [Test]
        public void TestDevelopmentDeckInitializesWithCorrectNumberOfRoadBuilding()
        {
            int roadBuildingCount = 0;
            foreach (CardType card in _controller.DevelopmentDeck)
            {
                if (card == CardType.RoadBuilding)
                {
                    roadBuildingCount++;
                }
            }

            Assert.AreEqual(2, roadBuildingCount);
        }

        [Test]
        public void TestDevelopmentDeckInitializesWithCorrectNumberOfVictoryPoints()
        {
            int victoryPointCount = 0;
            foreach (CardType card in _controller.DevelopmentDeck)
            {
                if (card == CardType.VictoryPoint)
                {
                    victoryPointCount++;
                }
            }

            Assert.AreEqual(5, victoryPointCount);
        }

        [Test]
        public void TestDevelopmentDeckInitializesWithCorrectNumberOfYearsOfPlenty()
        {
            int yearsOfPlentyCount = 0;
            foreach (CardType card in _controller.DevelopmentDeck)
            {
                if (card == CardType.YearOfPlenty)
                {
                    yearsOfPlentyCount++;
                }
            }

            Assert.AreEqual(2, yearsOfPlentyCount);
        }

        [Test]
        public void TestDevelopmentDeckInitializesWithCorrectSize()
        {
            Assert.AreEqual(25, _controller.DevelopmentDeck.Count);
        }

        [Test]
        public void TestDrawBrick()
        {
            CardType card = _controller.DrawResource(TileType.Hills);
            Assert.AreEqual(CardType.Brick, card);
        }

        [Test]
        public void TestDrawDevelopmentCard()
        {
            CardType card = _controller.DrawDevelopment();
            Assert.AreNotEqual(CardType.Brick, card);
            Assert.AreNotEqual(CardType.Wool, card);
            Assert.AreNotEqual(CardType.Lumber, card);
            Assert.AreNotEqual(CardType.Grain, card);
            Assert.AreNotEqual(CardType.Ore, card);
        }

        [Test]
        [ExpectedException(typeof (EmptyDeckException))]
        public void TestDrawEmptyDevelopmentCardDeck()
        {
            _controller.DevelopmentDeck = new ArrayList();
            CardType card = _controller.DrawDevelopment();
        }

        [Test]
        [ExpectedException(typeof (EmptyDeckException))]
        public void TestDrawEmptyResource()
        {
            _controller.ResourceDeck[TileType.Hills] = 0;
            CardType card = _controller.DrawResource(TileType.Hills);
        }

        [Test]
        public void TestDrawGrain()
        {
            CardType card = _controller.DrawResource(TileType.Fields);
            Assert.AreEqual(CardType.Grain, card);
        }

        [Test]
        [ExpectedException(typeof (KeyNotFoundException))]
        public void TestDrawInvalidTile()
        {
            CardType card = _controller.DrawResource(TileType.Port2);
        }

        [Test]
        public void TestDrawLumber()
        {
            CardType card = _controller.DrawResource(TileType.Woods);
            Assert.AreEqual(CardType.Lumber, card);
        }

        [Test]
        public void TestDrawOre()
        {
            CardType card = _controller.DrawResource(TileType.Mountains);
            Assert.AreEqual(CardType.Ore, card);
        }

        [Test]
        public void TestDrawWool()
        {
            CardType card = _controller.DrawResource(TileType.Pasture);
            Assert.AreEqual(CardType.Wool, card);
        }
    }
}