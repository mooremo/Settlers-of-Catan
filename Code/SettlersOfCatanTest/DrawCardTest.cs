﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    class DrawCardTest
    {
        private GameController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new GameController();    
        }

        [Test]
        public void TestDrawBrick()
        {
            var card = _controller.DrawResource(TileType.Hills);
            Assert.AreEqual(CardType.Brick, card);
        }

        [Test]
        public void TestDrawWool()
        {
            var card = _controller.DrawResource(TileType.Pasture);
            Assert.AreEqual(CardType.Wool, card);
        }

        [Test]
        public void TestDrawLumber()
        {
            var card = _controller.DrawResource(TileType.Woods);
            Assert.AreEqual(CardType.Lumber, card);
        }

        [Test]
        public void TestDrawGrain()
        {
            var card = _controller.DrawResource(TileType.Fields);
            Assert.AreEqual(CardType.Grain, card);
        }

        [Test]
        public void TestDrawOre()
        {
            var card = _controller.DrawResource(TileType.Mountains);
            Assert.AreEqual(CardType.Ore, card);
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestDrawInvalidTile()
        {
            var card = _controller.DrawResource(TileType.Port2);
        }

        [Test]
        [ExpectedException(typeof(EmptyDeckException))]
        public void TestDrawEmptyResource()
        {
            _controller.ResourceDeck[TileType.Hills] = 0;
            var card = _controller.DrawResource(TileType.Hills);
        }

        [Test]
        public void TestDevelopmentDeckInitializesWithCorrectSize()
        {
            Assert.AreEqual(25, _controller.DevelopmentDeck.Count);
        }

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
        public void TestDrawDevelopmentCard()
        {
            var card = _controller.DrawDevelopment();
            Assert.AreNotEqual(CardType.Brick, card);
            Assert.AreNotEqual(CardType.Wool,card);
            Assert.AreNotEqual(CardType.Lumber,card);
            Assert.AreNotEqual(CardType.Grain,card);
            Assert.AreNotEqual(CardType.Ore,card);
        }

        [Test]
        [ExpectedException(typeof(EmptyDeckException))]
        public void TestDrawEmptyDevelopmentCardDeck()
        {
            _controller.DevelopmentDeck = new ArrayList();
            var card = _controller.DrawDevelopment();
        }
    }
}
