using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    public class BoardTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            TestBoard = new Board();
        }

        #endregion

        public Board TestBoard;

        [Test]
        public void TestThatBoardHasFourFieldTiles()
        {
            int count = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Type == (int) TileType.Fields)
                {
                    count++;
                }
            }
            Assert.AreEqual(4, count);
        }

        [Test]
        public void TestThatBoardHasFourForestTiles()
        {
            int count = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Type == (int) TileType.Woods)
                {
                    count++;
                }
            }
            Assert.AreEqual(4, count);
        }

        [Test]
        public void TestThatBoardHasFourPastureTiles()
        {
            int count = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Type == (int) TileType.Pasture)
                {
                    count++;
                }
            }
            Assert.AreEqual(4, count);
        }

        [Test]
        public void TestThatBoardHasOneDesertTile()
        {
            int count = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Type == (int) TileType.Desert)
                {
                    count++;
                }
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestThatBoardHasThreeHillTiles()
        {
            int count = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Type == (int) TileType.Hills)
                {
                    count++;
                }
            }
            Assert.AreEqual(3, count);
        }

        [Test]
        public void TestThatBoardHasThreeMountainTiles()
        {
            int count = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Type == (int) TileType.Mountains)
                {
                    count++;
                }
            }
            Assert.AreEqual(3, count);
        }

        [Test]
        public void TestThatTilesHaveSixNeighbors()
        {
            int flag = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Neighbors.Count != 6)
                {
                    flag++;
                }
            }
            Assert.AreEqual(0, flag);
        }

        [Test]
        public void TestThatTilesIsFull()
        {
            Assert.AreEqual(19, TestBoard.TerrainTiles.Count);
        }

        [Test]
        public void TestThatTilesNeighborsInitializes()
        {
            int flag = 0;
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                if (t.Neighbors.Count == 0)
                {
                    flag++;
                }
            }
            Assert.AreEqual(0, flag);
        }

        [Test]
        public void TestThatTilesVerticesInitialize()
        {
            foreach (Tile t in TestBoard.TerrainTiles)
            {
                Assert.AreEqual(6, t.Vertices.Count);
            }
        }

        [Test]
        public void TestThatVerticesInitializes()
        {
            Assert.NotNull(TestBoard.Vertices);
        }

        [Test]
        public void TestThatVerticesNeighborsInitialize()
        {
            int flag = 0;
            foreach (Vertex v in TestBoard.Vertices)
            {
                if (v.Neighbors.Count == 0)
                {
                    flag++;
                }
            }
            Assert.AreEqual(0, flag);
        }

        [Test]
        public void TestThatVerticesHaveThreeNeighbors()
        {
            int flag = 0;
            foreach (Vertex v in TestBoard.Vertices)
            {
                if (v.Neighbors.Count != 3)
                {
                    flag++;
                }
            }
            Assert.AreEqual(0, flag);
        }
    }
}