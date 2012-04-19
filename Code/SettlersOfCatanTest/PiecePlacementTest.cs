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
            testPlayer = new Player();
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

        [Test()]
        public void TestThatVillageIsPlacedAtCorrectVertexWhenSettingUp()
        {
            testBoard.placePieceSetup(village, 1);
            Vertex targetVertex = (Vertex)testBoard.vertices[1];
            Assert.AreEqual(village, targetVertex.settlement);
        }

        [Test()]
        public void TestThatCityIsPlacedAtCorrectVertexWhenIsWhenSettingUp()
        {
            testBoard.placePieceSetup(city, 0);
            Vertex targetVertex = (Vertex)testBoard.vertices[0];
            Assert.AreEqual(city, targetVertex.settlement);
        }

        [Test()]
        public void TestThatRoadIsPlacedCorrectlyWhenIsWhenSettingUp()
        {
            testBoard.placePieceSetup(road, 0 , 0);
            Vertex targetVertex = (Vertex)testBoard.vertices[0];
            Assert.AreEqual(road, (Road) targetVertex.roads[0]);
            Vertex neighborVertex = (Vertex) targetVertex.neighbors[0];
            Assert.AreEqual(road, (Road)neighborVertex.roads[2]);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceThrowsOnBadVertex()
        {
            testBoard.placePiece(city, 99);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceSetupThrowsOnBadVertexWhenPlacingSettlement()
        {
            testBoard.placePieceSetup(city, 99);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceSetupThrowsOnBadVertexWhenPlacingRoad()
        {
            testBoard.placePieceSetup(road, 99, 3);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceSetupThrowsOnBadDirectionWhenPlacingRoad()
        {
            testBoard.placePieceSetup(road, 4, 3);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceBuildsOverVillage()
        {
            testBoard.placePieceSetup(city, 1);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceSetupThrowsWhenVertexAlreadyBuiltOnWithCity()
        {
            testBoard.placePieceSetup(city, 0);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlayerHasNoRoadToVertex()
        {
            testBoard.placePieceSetup(city, 8);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlacingRoadAndVertexHasNoNeighborInSpecifiedDirection()
        {
            testBoard.placePieceSetup(road, 0, 2);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlacingRoadAndAllRoadSpotsAtVertexAreTaken()
        {
            testBoard.placePieceSetup(city, 8);
            testBoard.placePieceSetup(road, 8, 0);
            testBoard.placePieceSetup(road, 8, 1);
            testBoard.placePieceSetup(road, 8, 2);
            testBoard.placePieceSetup(road, 8, 0);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlacingRoadAndHasNoRoadToVertex()
        {
            testBoard.placePieceSetup(road, 21, 0);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlacingCityAndHasNoRoadToVertex()
        {
            testBoard.placePieceSetup(city, 21);
        }

    }
}
