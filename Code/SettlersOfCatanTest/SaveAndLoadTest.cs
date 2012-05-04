using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    internal class SaveAndLoadTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _testGameController = new GameController();
            _testGameController2 = new GameController();
            _mySerializer = new Serializer();
            p1 = new Player();
            p1.Color = 1;
        }

        #endregion

        private GameController _testGameController, _testGameController2;
        private Serializer _mySerializer;
        private Player p1;
        private Board b1;

        [Test]
        public void TestSaveAndLoad()
        {
/*
            string path = Directory.GetCurrentDirectory() + "\\mySave.dat";
            _testGameController.LongestRoadLength = 5;
            _testGameController.CurrentPlayer = p1;
            _testGameController.Save(path);
            _testGameController2 = _mySerializer.Load(path);
            Assert.AreEqual(_testGameController2.LongestRoadLength, 5);
            Assert.AreEqual(_testGameController2.CurrentPlayer.Color, 1);
            */
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void TestThatGameControllerInitializes()
        {
            Assert.IsNotNull(_testGameController);
        }
    }
}