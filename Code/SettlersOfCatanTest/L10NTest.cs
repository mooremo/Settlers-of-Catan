using System.Globalization;
using System.Threading;
using NUnit.Framework;
using SettlersOfCatan.Properties;

namespace SettlersOfCatanTest
{
    [TestFixture]
    internal class L10NTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
        }

        #endregion

        [Test]
        public void TestEnglishResourcesLoadAndAreCorrect()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Assert.AreEqual(Resources.Cancel, "Cancel");
            Assert.AreEqual(Resources.color, "Color:");
            Assert.AreEqual(Resources.exit, "Exit");
            Assert.AreEqual(Resources.gameSetup, "Game Setup");
            Assert.AreEqual(Resources.loadGame, "Load Game");
            Assert.AreEqual(Resources.name, "Name:");
            Assert.AreEqual(Resources.newGame, "New Game");
            Assert.AreEqual(Resources.numberOfPlayers, "Number of Players:");
            Assert.AreEqual(Resources.OK, "OK");
            Assert.AreEqual(Resources.options, "Options");
            Assert.AreEqual(Resources.player, "Player");
            Assert.AreEqual(Resources.selectLanguage, "Choose a language:");
            Assert.AreEqual(Resources.startTitle, "Settlers of C#tan");
        }

        [Test]
        public void TestGermanResourcesLoadAndAreCorrect()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            Assert.AreEqual(Resources.Cancel, "Stornieren");
            Assert.AreEqual(Resources.color, "Farbe:");
            Assert.AreEqual(Resources.exit, "Ausgang");
            Assert.AreEqual(Resources.gameSetup, "Spielaufbau");
            Assert.AreEqual(Resources.loadGame, "Spiel Laden");
            Assert.AreEqual(Resources.name, "Namen:");
            Assert.AreEqual(Resources.newGame, "Neues Spiel");
            Assert.AreEqual(Resources.numberOfPlayers, "Anzahl der Spieler:");
            Assert.AreEqual(Resources.OK, "OK");
            Assert.AreEqual(Resources.options, "Optionen");
            Assert.AreEqual(Resources.player, "Spieler");
            Assert.AreEqual(Resources.selectLanguage, "Wählen Sie eine Sprache");
            Assert.AreEqual(Resources.startTitle, "Die Siedler von C#tan");
        }
    }
}