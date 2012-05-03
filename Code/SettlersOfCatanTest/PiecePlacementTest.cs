using System;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    public class PiecePlacementTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _testBoard = new Board();
            _testPlayer = new Player();
            _village = new Settlement(_testPlayer, SettlementType.Village);
            _city = new Settlement(_testPlayer, SettlementType.City);
            _road = new Road(_testPlayer);
        }

        #endregion

        private Board _testBoard;
        private Player _testPlayer;
        private Settlement _village;
        private Settlement _city;
        private Road _road;


        [Test]
        public void TestThatCityHasCorrectPlayerAfterConstruction()
        {
            Assert.AreSame(_testPlayer, _city.player);
        }

        [Test]
        public void TestThatCityHasCorrectTypeAfterConstruction()
        {
            Assert.AreEqual(SettlementType.City, _city.type);
        }

        [Test]
        public void TestThatCityInitializes()
        {
            Assert.IsNotNull(_city);
        }

        [Test]
        public void TestThatCityIsPlacedAtCorrectVertexWhenSettingUp()
        {
            _testBoard.PlacePieceSetup(_city, 0);
            Vertex targetVertex = _testBoard.Vertices[0];
            Assert.AreEqual(_city, targetVertex.Settlement);
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestThatPlacePieceBuildsOverVillage()
        {
            _testBoard.PlacePiece(_city, 1);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void TestThatPlacePieceSetupThrowsOnBadDirectionWhenPlacingRoad()
        {
            _testBoard.PlacePieceSetup(_road, 4, 3);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void TestThatPlacePieceSetupThrowsOnBadVertexWhenPlacingRoad()
        {
            _testBoard.PlacePieceSetup(_road, 99, 3);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void TestThatPlacePieceSetupThrowsOnBadVertexWhenPlacingSettlement()
        {
            _testBoard.PlacePieceSetup(_city, 99);
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestThatPlacePieceSetupThrowsWhenCityBuildOnVertexWithCityAlready()
        {
            _testBoard.PlacePieceSetup(_city, 0);
            _testBoard.PlacePieceSetup(_city, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void TestThatPlacePieceThrowsOnBadVertex()
        {
            _testBoard.PlacePiece(_city, 99);
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestThatPlacePieceThrowsWhenPlacingCityAndHasNoRoadToVertex()
        {
            _testBoard.PlacePiece(_city, 21);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlacingRoadAndAllRoadSpotsAtVertexAreTaken()
        {
            _testBoard.PlacePieceSetup(_city, 8);
            _testBoard.PlacePieceSetup(_road, 8, 0);
            _testBoard.PlacePieceSetup(_road, 8, 1);
            _testBoard.PlacePieceSetup(_road, 8, 2);
            _testBoard.PlacePieceSetup(_road, 8, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlacingRoadAndHasNoRoadToVertex()
        {
            _testBoard.PlacePieceSetup(_road, 21, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void TestThatPlacePieceThrowsWhenPlacingRoadAndVertexHasNoNeighborInSpecifiedDirection()
        {
            _testBoard.PlacePieceSetup(_road, 0, 2);
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestThatPlacePieceThrowsWhenPlacingVillageAndHasNoRoadToVertex()
        {
            _testBoard.PlacePiece(_village, 21);
        }

        [Test]
        public void TestThatRoadHasCorrectPlayerAfterConstruction()
        {
            Assert.AreSame(_testPlayer, _road.player);
        }

        [Test]
        public void TestThatRoadInitializes()
        {
            Assert.IsNotNull(_road);
        }

        [Test]
        public void TestThatRoadIsPlacedCorrectlyWhenSettingUp()
        {
            _testBoard.PlacePieceSetup(_city, 0);
            _testBoard.PlacePieceSetup(_road, 0, 0);
            Vertex targetVertex = _testBoard.Vertices[0];
            Assert.AreEqual(_road, targetVertex.Roads[0]);
            Vertex neighborVertex = targetVertex.Neighbors[0];
            Assert.AreEqual(_road, neighborVertex.Roads[2]);
        }

        [Test]
        public void TestThatVillageHasCorrectPlayerAfterConstruction()
        {
            Assert.AreSame(_testPlayer, _village.player);
        }

        [Test]
        public void TestThatVillageHasCorrectTypeAfterConstruction()
        {
            Assert.AreEqual(SettlementType.Village, _village.type);
        }

        [Test]
        public void TestThatVillageInitializes()
        {
            Assert.IsNotNull(_village);
        }

        [Test]
        public void TestThatVillageIsPlacedAtCorrectVertexWhenSettingUp()
        {
            _testBoard.PlacePieceSetup(_village, 1);
            Vertex targetVertex = _testBoard.Vertices[1];
            Assert.AreEqual(_village, targetVertex.Settlement);
        }
    }
}