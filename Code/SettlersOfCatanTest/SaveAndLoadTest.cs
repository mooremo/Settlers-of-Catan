using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    class SaveAndLoadTest
    {
        [SetUp]
        public void SetUp()
        {
            _testGameController = new GameController();
            _testGameController2 = new GameController();
        }

        [Test]
        public void TestThatGameControllerInitializes()
        {
            Assert.IsNotNull(_testGameController);
        }

        [Test]
        public void TestSaveAndLoad()
        {
            _testGameController.Save();
            _testGameController2.Load();
            Assert.AreEqual(_testGameController,_testGameController2);
        }
    }
}
