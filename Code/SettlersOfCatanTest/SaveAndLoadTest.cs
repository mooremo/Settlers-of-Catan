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
        }

        #endregion

        [Test]
        public void TestSaveAndLoad()
        {
            _testGameController.Save();
            _testGameController2.Load();
            Assert.AreEqual(_testGameController, _testGameController2);
        }

        [Test]
        public void TestThatGameControllerInitializes()
        {
            Assert.IsNotNull(_testGameController);
        }
    }
}