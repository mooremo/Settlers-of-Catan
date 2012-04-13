using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture()]
    public class PiecePlacementTest
    {
        private Board testBoard;
        private Player testPlayer;
        private Settlement village;
        private Settlement city;
        private Road road;


        [SetUp()]
        public void SetUp()
        {
            testBoard = new Board();
            village = new Settlement(testPlayer,SettlementType.Village);
            city = new Settlement(testPlayer,SettlementType.City);
            road = new Road(testPlayer);
        }

        [Test()]
        public void TestThatVillageInitializes()
        {
            Assert.IsNotNull(village);
        }

        [Test()]
        public void TestThatCityInitializes()
        {
            Assert.IsNotNull(city);
        }

        [Test()]
        public void TestThatRoadInitializes()
        {
            Assert.IsNotNull(road);
        }

        [Test()]
        public void TestThatVillageHasCorrectTypeAfterConstruction()
        {
            Assert.AreEqual(SettlementType.Village, village.type);
        }

        [Test()]
        public void TestThatCityHasCorrectTypeAfterConstruction()
        {
            Assert.AreEqual(SettlementType.City, city.type);
        }

        [Test()]
        public void TestThatVillageHasCorrectPlayerAfterConstruction()
        {
            Assert.AreSame(testPlayer, village.player);
        }

        [Test()]
        public void TestThatCityHasCorrectPlayerAfterConstruction()
        {
            Assert.AreSame(testPlayer, city.player);
        }

        [Test()]
        public void TestThatRoadHasCorrectPlayerAfterConstruction()
        {
            Assert.AreSame(testPlayer, road.player);
        }
    }
}
