using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SettlersOfCatan;

namespace SettlersOfCatanTest
{
    [TestFixture]
    class ScoringTest
    {

        private GameController _controller;
        private Board _board;
        private Player _player1;
        private Player _player2;
        private Player _player3;
        private Player _player4;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();

            _player1 = new Player();
            _player2 = new Player();
            _player3 = new Player();
            _player4 = new Player();

            _controller.Board = _board;

            _controller.Players.Add(_player1);
            _controller.Players.Add(_player2);
            _controller.Players.Add(_player3);
            _controller.Players.Add(_player4);
        }

        [Test]
        // All players should start with no score
        public void TestEmptyBoardHasNoScore()
        {
            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Each village is worth 1 points
        public void TestVillageHasOnePoint()
        {
            var village = new Settlement(_player1, SettlementType.Village);
            ((Vertex) _board.Vertices[0]).Settlement = village;

            _controller.ScorePlayers();

            Assert.AreEqual(1, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Test that multiple villages get counted
        public void TestTwoVillagesHasTwoPoints()
        {
            var village = new Settlement(_player1, SettlementType.Village);
            ((Vertex) _board.Vertices[0]).Settlement = village;
            ((Vertex)_board.Vertices[1]).Settlement = village;

            _controller.ScorePlayers();

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Each city is worth 2 points
        public void TestCityHasTwoPoints()
        {
            var city = new Settlement(_player1, SettlementType.City);
            ((Vertex)_board.Vertices[0]).Settlement = city;

            _controller.ScorePlayers();

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Test that multiple cities get counted
        public void TestTwoCitiesHasFourPoints()
        {
            var city = new Settlement(_player1, SettlementType.City);
            ((Vertex)_board.Vertices[0]).Settlement = city;
            ((Vertex)_board.Vertices[1]).Settlement = city;

            _controller.ScorePlayers();

            Assert.AreEqual(4, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Test a mix of a village and city
        public void TestVillageAndCityHasThreePoints()
        {
            var village = new Settlement(_player1, SettlementType.Village);
            var city = new Settlement(_player1, SettlementType.City);
            ((Vertex)_board.Vertices[0]).Settlement = village;
            ((Vertex)_board.Vertices[1]).Settlement = city;

            _controller.ScorePlayers();

            Assert.AreEqual(3, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        [Ignore]
        // Each victory card awards 1 point
        public void TestVictoryCardHasOnePoint()
        {
            _player1.PlayedDevelopmentCards.Add(CardType.VictoryPoint);

            _controller.ScorePlayers();

            Assert.AreEqual(1, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Longest Road requires at least 5 connected segments
        public void TestOneRoadDoesNotGiveLongestRoad()
        {
            var road = new Road(_player1);
            ((Vertex) _board.Vertices[0]).Roads[0] = road;

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        public void TestTwoRoadsDoesNotGiveLongestRoad()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            ((Vertex) _board.Vertices[0]).Roads[0] = road1;
            ((Vertex) _board.Vertices[1]).Roads[1] = road2;

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        public void TestThreeRoadsDoesNotGiveLongestRoad()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            var road3 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        public void TestFourRoadsDoesNotGiveLongestRoad()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            var road3 = new Road(_player1);
            var road4 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;
            ((Vertex)_board.Vertices[9]).Roads[2] = road4;

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Five contiguous road segments awards 2 points
        public void TestFiveConnectedRoadsGivesLongestRoad()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            var road3 = new Road(_player1);
            var road4 = new Road(_player1);
            var road5 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;
            ((Vertex)_board.Vertices[9]).Roads[2] = road4;
            ((Vertex)_board.Vertices[8]).Roads[1] = road5;

            _controller.ScorePlayers();

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Longest road only gets awarded when all 5 pieces are owned by the
        // same player
        public void TestConnectedRoadWithMultiplePlayersDoesNotAwardLongestRoad()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player2);
            var road3 = new Road(_player3);
            var road4 = new Road(_player4);
            var road5 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;
            ((Vertex)_board.Vertices[9]).Roads[2] = road4;
            ((Vertex)_board.Vertices[8]).Roads[1] = road5;

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Ensure we don't count a road > 5 pieces more than once
        public void TestSixConnectedRoadsOnlyGivesTwoPoints()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            var road3 = new Road(_player1);
            var road4 = new Road(_player1);
            var road5 = new Road(_player1);
            var road6 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;
            ((Vertex)_board.Vertices[9]).Roads[2] = road4;
            ((Vertex)_board.Vertices[8]).Roads[1] = road5;
            ((Vertex)_board.Vertices[14]).Roads[1] = road6;

            _controller.ScorePlayers();

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Ensure we don't count a road with a fork more than once
        public void TestForkedRoadOnlyGivesTwoPoints()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            var road3 = new Road(_player1);
            var road4 = new Road(_player1);
            var road5 = new Road(_player1);
            var road6 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;
            ((Vertex)_board.Vertices[9]).Roads[2] = road4;
            ((Vertex)_board.Vertices[8]).Roads[1] = road5;
            ((Vertex)_board.Vertices[8]).Roads[2] = road6;

            _controller.ScorePlayers();

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // The five road segments must be contiguous, or no points awarded
        public void TestFiveUnconnectedSegmentsDoesNotGiveLongestRoad()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            var road3 = new Road(_player1);
            var road4 = new Road(_player1);
            var road5 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;
            
            ((Vertex)_board.Vertices[8]).Roads[1] = road4;
            ((Vertex)_board.Vertices[8]).Roads[2] = road5;

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Only one Longest Road can be awarded. Ensure that its given to the player with
        // the higher length
        public void TestLongestRoadAwardedToLongestRoad()
        {
            var road1 = new Road(_player1);
            var road2 = new Road(_player1);
            var road3 = new Road(_player1);
            var road4 = new Road(_player1);
            var road5 = new Road(_player1);
            ((Vertex)_board.Vertices[0]).Roads[0] = road1;
            ((Vertex)_board.Vertices[1]).Roads[1] = road2;
            ((Vertex)_board.Vertices[4]).Roads[1] = road3;
            ((Vertex)_board.Vertices[9]).Roads[2] = road4;
            ((Vertex)_board.Vertices[8]).Roads[1] = road5;

            var road6 = new Road(_player2);
            var road7 = new Road(_player2);
            var road8 = new Road(_player2);
            var road9 = new Road(_player2);
            var road10 = new Road(_player2);
            var road11 = new Road(_player2);
            ((Vertex)_board.Vertices[0]).Roads[0] = road6e;
            ((Vertex)_board.Vertices[1]).Roads[1] = road7e;
            ((Vertex)_board.Vertices[4]).Roads[1] = road8e;
            ((Vertex)_board.Vertices[9]).Roads[2] = road9e;
            ((Vertex)_board.Vertices[8]).Roads[1] = road10e;
            ((Vertex)_board.Vertices[8]).Roads[1] = road11e;

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(2, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Another player must _exceed_ the current longest road to get the points
        public void TestLongestRoadDoesNotTransferWhenEqualled()
        {
            
        }

        [Test]
        // Sees that the points get transferred to the new longest road
        public void TestLongestRoadTransfersWhenExceeded()
        {
            
        }

        [Test]
        // Player must have at least 3 knights to be awarded points
        public void TestOneKnightDoesNotAwardLargestArmy()
        {
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        public void TestTwoKnightsDoNotAwardLargestArmy()
        {
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // First to 3 knights gets awarded 2 points
        public void TestThreeKnightsAwardsLargestArmy()
        {
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreSame(_player1, _controller.LargestArmy);

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Only one Largest Army can be awarded. Ensure that its given to the
        // player with the most knights played
        public void TestLargestArmyAwardedToLargestArmy()
        {
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);

            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreSame(_player2, _controller.LargestArmy);

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(2, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // A player must _exceed_ the current largest army to get the points
        public void TestLargestArmyDoesNotTransferWhenEqualled()
        {
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreSame(_player1, _controller.LargestArmy);

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);

            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreSame(_player1, _controller.LargestArmy);

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Check that points get transferred properly
        public void TestLargestArmyTransfersWhenExceeded()
        {
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);
            _player1.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreSame(_player1, _controller.LargestArmy);

            Assert.AreEqual(2, _player1.Score);
            Assert.AreEqual(0, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);

            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);
            _player2.PlayedDevelopmentCards.Add(CardType.Solider);

            _controller.ScorePlayers();

            Assert.AreSame(_player2, _controller.LargestArmy);

            Assert.AreEqual(0, _player1.Score);
            Assert.AreEqual(2, _player2.Score);
            Assert.AreEqual(0, _player3.Score);
            Assert.AreEqual(0, _player4.Score);
        }

        [Test]
        // Ensures that some preset configuration of the game state awards
        // the correct number of points for one player
        public void TestMixConfigurationOnePlayer()
        {
            
        }

        [Test]
        // Same as above, but each player must get the correct score
        public void TestMixConfigurationTwoPlayer()
        {
            
        }

        [Test]
        public void TestMixConfigurationThreePlayer()
        {
            
        }

        [Test]
        public void TestMixConfigurationFourPlayer()
        {
            
        }
    }
}
