using NUnit.Framework;

namespace SettlersOfCatanTest
{
    [TestFixture]
    internal class ScoringTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
        }

        #endregion

        [Test]
        // Each city is worth 2 points
        public void TestCityHasTwoPoints()
        {
        }

        [Test]
        // Longest road only gets awarded when all 5 pieces are owned by the
        // same player
        public void TestConnectedRoadWithMultiplePlayersDoesNotAwardLongestRoad()
        {
        }

        [Test]
        // All players should start with no score
        public void TestEmptyBoardHasNoScore()
        {
        }

        [Test]
        // Five contiguous road segments awards 2 points
        public void TestFiveConnectedRoadsGivesLongestRoad()
        {
        }

        [Test]
        // The five road segments must be contiguous, or no points awarded
        public void TestFiveUnconnectedSegmentsDoesNotGiveLongestRoad()
        {
        }

        [Test]
        public void TestFourRoadsDoesNotGiveLongestRoad()
        {
        }

        [Test]
        // Only one Largest Army can be awarded. Ensure that its given to the
        // player with the most knights played
        public void TestLargestArmyAwardedToLargestArmy()
        {
        }

        [Test]
        // A player must _exceed_ the current largest army to get the points
        public void TestLargestArmyDoesNotTransferWhenEqualled()
        {
        }

        [Test]
        // Check that points get transferred properly
        public void TestLargestArmyTransfersWhenExceeded()
        {
        }

        [Test]
        // Only one Longest Road can be awarded. Ensure that its given to the player with
        // the higher length
        public void TestLongestRoadAwardedToLongestRoad()
        {
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
        public void TestMixConfigurationFourPlayer()
        {
        }

        [Test]
        // Ensures that some preset configuration of the game state awards
        // the correct number of points for one player
        public void TestMixConfigurationOnePlayer()
        {
        }

        [Test]
        public void TestMixConfigurationThreePlayer()
        {
        }

        [Test]
        // Same as above, but each player must get the correct score
        public void TestMixConfigurationTwoPlayer()
        {
        }

        [Test]
        // Player must have at least 3 knights to be awarded points
        public void TestOneKnightDoesNotAwardLargestArmy()
        {
        }

        [Test]
        // Longest Road requires at least 5 connected segments
        public void TestOneRoadDoesNotGiveLongestRoad()
        {
        }

        [Test]
        // Ensure we don't count a road > 5 pieces more than once
        public void TestSixConnectedRoadsOnlyGivesTwoPoints()
        {
        }

        [Test]
        // First to 3 knights gets awarded 2 points
        public void TestThreeKnightsAwardsLargestArmy()
        {
        }

        [Test]
        public void TestThreeRoadsDoesNotGiveLongestRoad()
        {
        }

        [Test]
        // Test that multiple cities get counted
        public void TestTwoCitiesHasFourPoints()
        {
        }

        [Test]
        public void TestTwoKnightsDoNotAwardLargestArmy()
        {
        }

        [Test]
        public void TestTwoRoadsDoesNotGiveLongestRoad()
        {
        }

        [Test]
        // Test that multiple villages get counted
        public void TestTwoVillagesHasTwoPoints()
        {
        }

        [Test]
        // Each victory card awards 1 point
        public void TestVictoryCardHasOnePoint()
        {
        }

        [Test]
        // Test a mix of a village and city
        public void TestVillageAndCityHasThreePoints()
        {
        }

        [Test]
        // Each village is worth 1 points
        public void TestVillageHasOnePoint()
        {
        }
    }
}