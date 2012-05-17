using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    [Serializable]
    public class GameController : ISerializable
    {
        public Player CurrentPlayer;

        public GameController(SerializationInfo info, StreamingContext ctxt)
        {
            CurrentPlayer = (Player) info.GetValue("CurrentPlayer", typeof (Player));
            Board = (Board) info.GetValue("Board", typeof (Board));
            Dice = (Dice) info.GetValue("Dice", typeof (Dice));
            Players = (List<Player>) info.GetValue("Players", typeof (ArrayList));
            ResourceDeck = (Dictionary<TileType, int>) info.GetValue("ResourceDeck", typeof (Dictionary<TileType, int>));
            ResourceLookup =
                (Dictionary<TileType, CardType>)
                info.GetValue("ResourceLookup", typeof (Dictionary<TileType, CardType>));
            DevelopmentDeck = (List<CardType>) info.GetValue("DevelopmentDeck", typeof (ArrayList));
            LongestRoad = (Player) info.GetValue("LongestRoad", typeof (Player));
            LargestArmy = (Player) info.GetValue("LargestArmy", typeof (Player));
            LongestRoadLength = (int) info.GetValue("LongestRoadLength", typeof (int));
        }

        public GameController()
        {
            Dice = new Dice();
            Players = new List<Player>();
            Board = new Board();
            InitializeResourceLookup();
            InitializeResourceDeck();
            InitializeDevelopmentDeck();
        }

        public GameController(List<Player> players)
        {
            Dice = new Dice();
            Players = players;
            CurrentPlayer = Players[0];
            Board = new Board();
            InitializeResourceLookup();
            InitializeResourceDeck();
            InitializeDevelopmentDeck();

            CurrentPlayer = PickFirstPlayer();
        }

        public Board Board { get; set; }
        public Dice Dice { get; set; }
        public List<Player> Players { get; set; }
        public Dictionary<TileType, int> ResourceDeck { get; set; }
        public Dictionary<TileType, CardType> ResourceLookup { get; set; }
        public List<CardType> DevelopmentDeck { get; set; }
        public Player LongestRoad { get; set; }
        public int LongestRoadLength { get; set; }
        public Player LargestArmy { get; set; }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("CurrentPlayer", CurrentPlayer);
            info.AddValue("Board", Board);
            info.AddValue("Dice", Dice);
            info.AddValue("Players", Players);
            info.AddValue("ResourceDeck", ResourceDeck);
            info.AddValue("ResourceLookup", ResourceLookup);
            info.AddValue("DevelopmentDeck", DevelopmentDeck);
            info.AddValue("LongestRoad", LongestRoad);
            info.AddValue("LargestArmy", LargestArmy);
            info.AddValue("LongestRoadLength", LongestRoadLength);
        }

        #endregion

        public void Save(string fileName)
        {
            var temp = new Serializer();
            temp.Save(this, fileName);
        }

        private void InitializeResourceLookup()
        {
            ResourceLookup = new Dictionary<TileType, CardType>
                                 {
                                     {TileType.Fields, CardType.Grain},
                                     {TileType.Woods, CardType.Lumber},
                                     {TileType.Hills, CardType.Brick},
                                     {TileType.Mountains, CardType.Ore},
                                     {TileType.Pasture, CardType.Wool}
                                 };
        }

        private void InitializeResourceDeck()
        {
            ResourceDeck = new Dictionary<TileType, int>
                               {
                                   {TileType.Fields, 19},
                                   {TileType.Woods, 19},
                                   {TileType.Hills, 19},
                                   {TileType.Mountains, 19},
                                   {TileType.Pasture, 19}
                               };
        }

        private void InitializeDevelopmentDeck()
        {
            var developmentCount = new Dictionary<CardType, int>
                                       {
                                           {CardType.Soldier, 14},
                                           {CardType.Monopoly, 2},
                                           {CardType.RoadBuilding, 2},
                                           {CardType.YearOfPlenty, 2},
                                           {CardType.VictoryPoint, 5}
                                       };

            DevelopmentDeck = new List<CardType>();
            foreach (CardType card in developmentCount.Keys)
            {
                for (int i = 0; i < developmentCount[card]; i++)
                {
                    DevelopmentDeck.Add(card);
                }
            }

            Shuffler.Shuffle(DevelopmentDeck);
        }

        public CardType DrawResource(TileType tile)
        {
            if (ResourceDeck[tile] <= 0)
            {
                throw new EmptyDeckException();
            }

            ResourceDeck[tile] -= 1;
            return ResourceLookup[tile];
        }

        public CardType DrawDevelopment()
        {
            if (DevelopmentDeck.Count == 0)
            {
                throw new EmptyDeckException();
            }

            CardType ret = DevelopmentDeck[0];
            DevelopmentDeck.RemoveAt(0);
            return ret;
        }

        // Iterates through players and calculates score for each
        public void ScorePlayers()
        {
            ClearScores();
            ScoreSettlements();
            ScoreVictoryPointCards();
            AwardLongestRoad();
            AwardLargestArmy();
        }

        private void AwardLargestArmy()
        {
            Dictionary<Player, int> armies = CountArmies();
            int armyToBeat = 2;
            if (LargestArmy != null)
            {
                armyToBeat = armies[LargestArmy];
            }

            foreach (Player player in Players)
            {
                if (armies[player] > armyToBeat)
                {
                    LargestArmy = player;
                    armyToBeat = armies[player];
                }
            }

            if (LargestArmy != null)
            {
                LargestArmy.Score += 2;
            }
        }

        private Dictionary<Player, int> CountArmies()
        {
            var result = new Dictionary<Player, int>();
            foreach (Player player in Players)
            {
                int count = 0;
                foreach (CardType card in player.PlayedDevelopmentCards)
                {
                    if (card == CardType.Soldier)
                    {
                        count++;
                    }
                }
                result.Add(player, count);
            }

            return result;
        }

        private void AwardLongestRoad()
        {
            if (LongestRoad == null)
            {
                LongestRoadLength = 4;
            }

            var longestRoadPerPlayer = new Dictionary<Player, int>();
            foreach (Player player in Players)
            {
                ResetRoadMarks();
                List<List<Road>> sets = PartitionRoads(player);
                longestRoadPerPlayer.Add(player, FindLongestRoadInSet(sets));
            }

            foreach (Player player in Players)
            {
                if (longestRoadPerPlayer[player] > LongestRoadLength)
                {
                    LongestRoad = player;
                    LongestRoadLength = longestRoadPerPlayer[player];
                }
            }

            if (LongestRoad != null)
            {
                LongestRoad.Score += 2;
            }
        }

        /*
         * Given a player and his/her connected road groups,
         * finds the longest one
         */

        private int FindLongestRoadInSet(List<List<Road>> sets)
        {
            int longest = 0;

            foreach (var road in sets)
            {
                List<Road> endPoints = FindEndPoints(road);
                foreach (Road endPoint in endPoints)
                {
                    ResetRoadMarks();
                    int curRoad = MeasureRoad(endPoint, 0);
                    if (curRoad > longest)
                    {
                        longest = curRoad;
                    }
                }
            }

            return longest;
        }

        /*
         * Finds the length of a connected road by traversing depth-first
         * from an end point
         */

        private int MeasureRoad(Road curRoad, int length)
        {
            curRoad.Marked = true;

            int bestSoFar = 0;
            foreach (int index in curRoad.Indices)
            {
                Vertex vertex = Board.Vertices[index];
                foreach (Road nextRoad in vertex.Roads)
                {
                    if (nextRoad != null && !nextRoad.Marked && nextRoad.player == curRoad.player)
                    {
                        int thisPath = MeasureRoad(nextRoad, length + 1);
                        if (thisPath > bestSoFar)
                        {
                            bestSoFar = thisPath;
                        }
                    }
                }
            }

            return bestSoFar + 1;
        }

        /*
         * Finds all of the road segments that do not have additional
         * roads on either end. If there are none, it selects the first
         * segment in the array
         */

        private List<Road> FindEndPoints(List<Road> road)
        {
            var endPoints = new List<Road>();

            foreach (Road roadPiece in road)
            {
                // Look at either end of the piece
                foreach (int index in roadPiece.Indices)
                {
                    Vertex vertex = Board.Vertices[index];

                    bool endFlag = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (vertex.Roads[i] != null && vertex.Roads[i] != roadPiece)
                        {
                            // If there are other roads connecting, they shouldn't
                            // belong to the current player
                            if ((vertex.Roads[i]).player == roadPiece.player)
                            {
                                endFlag = false;
                                break;
                            }
                        }
                    }

                    if (endFlag)
                    {
                        endPoints.Add(roadPiece);
                        break;
                    }
                }
            }

            if (endPoints.Count == 0)
                return new List<Road>(new[] {road[0]});
            return endPoints;
        }

        /*
         * Unmarks all road segments
         */

        private void ResetRoadMarks()
        {
            foreach (Vertex vertex in Board.Vertices)
            {
                foreach (Road road in vertex.Roads)
                {
                    if (road != null)
                    {
                        road.Marked = false;
                    }
                }
            }
        }

        /*
         * For a particular player, groups his/her road pieces into connected
         * partitions. 
         */

        private List<List<Road>> PartitionRoads(Player player)
        {
            var sets = new List<List<Road>>();

            foreach (Vertex vertex in Board.Vertices)
            {
                foreach (Road road in vertex.Roads)
                {
                    if (road != null && road.player == player && !road.Marked)
                    {
                        sets.Add(TraverseRoad(road, player, new List<Road>()));
                    }
                }
            }

            return sets;
        }

        /*
         * Traverses all connected road segments depth-first and adds them to
         * a list
         */

        private List<Road> TraverseRoad(Road road, Player player, List<Road> list)
        {
            list.Add(road);
            road.Marked = true;

            foreach (int i in road.Indices)
            {
                Vertex vertex = Board.Vertices[i];
                for (int j = 0; j < 3; j++)
                {
                    Road nextRoad = vertex.Roads[j];
                    if (nextRoad != null && !nextRoad.Marked && nextRoad.player == player &&
                        (vertex.Settlement == null || vertex.Settlement.player == player))
                    {
                        list = TraverseRoad(nextRoad, player, list);
                    }
                }
            }

            return list;
        }

        private void ScoreVictoryPointCards()
        {
            foreach (Player player in Players)
            {
                foreach (CardType card in player.PlayedDevelopmentCards)
                {
                    if (card == CardType.VictoryPoint)
                    {
                        player.Score++;
                    }
                }
            }
        }

        private void ClearScores()
        {
            foreach (Player player in Players)
            {
                player.Score = 0;
            }
        }

        // Grants a point for each village and two for cities
        public void ScoreSettlements()
        {
            foreach (Vertex vertex in Board.Vertices)
            {
                if (vertex.Settlement != null)
                {
                    if (vertex.Settlement.type == SettlementType.Village)
                    {
                        vertex.Settlement.player.Score++;
                    }
                    else if (vertex.Settlement.type == SettlementType.City)
                    {
                        vertex.Settlement.player.Score += 2;
                    }
                }
            }
        }

        // Changes the current player to the next player in Players
        public void ChangeCurrentPlayer()
        {
            int index = Players.IndexOf(CurrentPlayer);
            if (index + 1 < Players.Count)
            {
                CurrentPlayer = Players[index + 1];
            }
            else
            {
                CurrentPlayer = Players[0];
            }
        }

        public void ChangeCurrentPlayerReverse()
        {
            int index = Players.IndexOf(CurrentPlayer);
            if (index - 1 >= 0 )
            {
                CurrentPlayer = Players[index - 1];
            }
            else
            {
                CurrentPlayer = Players[Players.Count - 1];
            }
        }

        //Grants a resource for each settlement adjacent
        //to the hex with the number rolled
        public void AwardResourceForSettlementAdjacentToRolledHex()
        {
            foreach (Tile tile in Board.TerrainTiles)
            {
                if (tile.Type != TileType.Desert)
                {
                    if (tile.Number == Dice.Value)
                    {
                        foreach (Vertex vertex in tile.Vertices)
                        {
                            if (vertex.Settlement != null)
                            {
                                if (vertex.Settlement.type == SettlementType.Village)
                                {
                                    vertex.Settlement.player.ResourceHand.Add(
                                        DrawResource((TileType) tile.Type));
                                }
                                else if (vertex.Settlement.type == SettlementType.City)
                                {
                                    vertex.Settlement.player.ResourceHand.Add(
                                        DrawResource((TileType) tile.Type));
                                    vertex.Settlement.player.ResourceHand.Add(
                                        DrawResource((TileType) tile.Type));
                                }
                            }
                        }
                    }
                }
            }
        }

        //Removes half the resource hand of each player
        //with over 7 resource cards
        public void DiscardForMoreThanSeven()
        {
            foreach (Player player in Players)
            {
                if (player.ResourceHand.Count > 6)
                {
                    int count = player.ResourceHand.Count;
                    int numberToRemove = (count%2 == 0) ? count/2 : (count - 1)/2;
                    while (numberToRemove > 0)
                    {
                        player.Discard(0);
                        numberToRemove--;
                    }
                }
            }
        }

        //Rolls the dice and does checks
        public void RollDice()
        {
            Dice.Roll();
            if (Dice.Value == 7)
            {
                DiscardForMoreThanSeven();
            }
            else
            {
                AwardResourceForSettlementAdjacentToRolledHex();
            }
        }

        public bool TradeWithBank(int cardTypeToTrade, int cardTypeToGet)
        {
            return false;
        }

        public bool TradeAtPort(int portNumber, int cardTypeToTrade, int cardTypeToGet)
        {
            return false;
        }

        public bool TradeWithAnotherPlayer(int playerNumber, int cardTypeToTrade, int numberToTrade, int cardeTypeToGet,
                                           int numberToGet)
        {
            return false;
        }

        public Player PickFirstPlayer()
        {
            var rng = new Random(new System.DateTime().Millisecond).Next(Players.Count);
            return Players[rng];
        }
    }

    public class EmptyDeckException : Exception
    {
    }
}