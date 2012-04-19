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
            testBoard = new Board();
        }

        #endregion

        private Board testBoard;

        [Test]
        public void TestThatBoardHasFourFieldTiles()
        {
            int count = 0;
            foreach (Tile t in testBoard.Tiles)
            {
                if (t.type == 1)
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
            foreach (Tile t in testBoard.Tiles)
            {
                if (t.type == 2)
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
            foreach (Tile t in testBoard.Tiles)
            {
                if (t.type == 3)
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
            foreach (Tile t in testBoard.Tiles)
            {
                if (t.type == 6)
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
            foreach (Tile t in testBoard.Tiles)
            {
                if (t.type == 5)
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
            foreach (Tile t in testBoard.Tiles)
            {
                if (t.type == 4)
                {
                    count++;
                }
            }
            Assert.AreEqual(3, count);
        }

        [Test]
        public void TestThatBoardInitializes()
        {
            Assert.IsNotNull(testBoard);
        }

        [Test]
        [Ignore("The method count has not been implemented")]
        public void TestThatTilesIsFull()
        {
            Assert.AreEqual(21, testBoard.Tiles.Count);
        }
    }
}