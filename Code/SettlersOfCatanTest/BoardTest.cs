using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture()]
    public class BoardTest
    {
        private Board testBoard;

        [SetUp]
        public void SetUp()
        {
            testBoard = new Board();
        }

        [Test()]
        public void TestThatBoardInitializes()
        {
            Assert.IsNotNull(testBoard);
        }

        [Test()]
        public void TestThatTilesIsFull()
        {
            Assert.AreEqual(19, testBoard.TerrainTiles.Count);
        }

        [Test()]
        public void TestThatBoardHasFourFieldTiles()
        {
            int count = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if (t.Type == (int)TileType.Fields)
                {
                    count++;
                }
            }
            Assert.AreEqual(4, count);
        }

        [Test()]
        public void TestThatBoardHasFourForestTiles()
        {
            int count = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if (t.Type == (int)TileType.Woods)
                {
                    count++;
                }
            }
            Assert.AreEqual(4, count);
        }

        [Test()]
        public void TestThatBoardHasFourPastureTiles()
        {
            int count = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if (t.Type == (int)TileType.Pasture)
                {
                    count++;
                }
            }
            Assert.AreEqual(4, count);
        }

        [Test()]
        public void TestThatBoardHasThreeMountainTiles()
        {
            int count = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if (t.Type == (int)TileType.Mountains)
                {
                    count++;
                }
            }
            Assert.AreEqual(3, count);
        }

        [Test()]
        public void TestThatBoardHasThreeHillTiles()
        {
             int count = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if (t.Type == (int)TileType.Hills)
                {
                    count++;
                }
            }
            Assert.AreEqual(3, count);
        }

        [Test()]
        public void TestThatBoardHasOneDesertTile()
        {
            int count = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if (t.Type == (int)TileType.Desert)
                {
                    count++;
                }
            }
            Assert.AreEqual(1, count);
        }
        [Test()]
        public void TestThatTilesNeighborsInitializes()
        {
            int flag = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if (t.Neighbors.Count == 0)
                {
                    flag++;
                }
            }
            Assert.AreEqual(0, flag);
        }

        [Test()]
        public void TestThatTilesHaveSixNeighbors()
        {
            int flag = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                if(t.Neighbors.Count != 6)
                {
                    flag++;
                }
            }
            Assert.AreEqual(0, flag);
        }

        [Test()]
        public void TestThatVerticesInitializes()
        {
            Assert.NotNull(testBoard.Vertices);
        }

        [Test()]
        public void TestThatTilesVerticesInitialize()
        {
            int flag = 0;
            foreach (Tile t in testBoard.TerrainTiles)
            {
                Assert.AreEqual(6, t.Vertices.Count);
            }
        }
    }
}
