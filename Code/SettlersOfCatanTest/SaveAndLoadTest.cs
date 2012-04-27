﻿using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    internal class SaveAndLoadTest
    {
        #region Setup/Teardown

        private GameController _testGameController, _testGameController2;
        private Serializer _mySerializer;
        private Player p1;
        private Board b1;

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

        [Test]
        public void TestSaveAndLoad()
        {
            _testGameController.LongestRoadLength = 5;
            _testGameController.CurrentPlayer = p1;
            _testGameController.Save("C:\\Users\\Matthew\\Desktop\\test.dat");
            _testGameController2 = _mySerializer.Load("C:\\Users\\Matthew\\Desktop\\test.dat");
            Assert.AreEqual(_testGameController2.LongestRoadLength, 5);
            Assert.AreEqual(_testGameController2.CurrentPlayer.Color, 1);
        }

        [Test]
        public void TestThatGameControllerInitializes()
        {
            Assert.IsNotNull(_testGameController);
        }
    }
}