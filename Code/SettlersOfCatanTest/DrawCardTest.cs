using System;
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDrawInvalidTile()
        {
            var card = _controller.DrawResource(TileType.Port2);
        }

        [Test]
        public void TestDrawEmptyResource()
        {
            _controller.resourceDeck[TileType.Hills] = 0;
            var card = _controller.DrawResource(TileType.Hills);

            //What should happen here?
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
        public void TestDrawEmptyDevelopmentCardDeck()
        {
            _controller.developmentDeck = new ArrayList();
            var card = _controller.DrawDevelopment();

            // Again...
        }
    }
}
