using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SettlersOfCatan
{
    [Serializable]
    public class GameController : ISerializable
    {
        public Player CurrentPlayer;
        public Board Board { get; set; }
        public Dice Dice { get; set; }
        public ArrayList Players { get; set; }
        public Dictionary<TileType, int> ResourceDeck { get; set; }
        public Dictionary<TileType, CardType> ResourceLookup { get; set; }
        public ArrayList DevelopmentDeck { get; set; }
        public Player LongestRoad { get; set; }
        public int LongestRoadLength { get; set; }
        public Player LargestArmy { get; set; }

        public GameController(SerializationInfo info, StreamingContext ctxt)
       {
            this.CurrentPlayer = (Player)info.GetValue("CurrentPlayer", typeof(Player));
            this.Board = (Board)info.GetValue("Board", typeof(Board));
            this.Dice = (Dice)info.GetValue("Dice", typeof(Dice));
            this.Players = (ArrayList)info.GetValue("Players", typeof(ArrayList));
            this.ResourceDeck = (Dictionary<TileType, int>)info.GetValue("ResourceDeck", typeof(Dictionary<TileType, int>));
            this.ResourceLookup = (Dictionary<TileType, CardType>)info.GetValue("ResourceLookup", typeof(Dictionary<TileType, CardType>));
            this.DevelopmentDeck = (ArrayList)info.GetValue("DevelopmentDeck", typeof(ArrayList));
            this.LongestRoad = (Player)info.GetValue("LongestRoad", typeof(Player));
            this.LargestArmy = (Player)info.GetValue("LargestArmy", typeof(Player));
            this.LongestRoadLength = (int)info.GetValue("LongestRoadLength", typeof(int));
       }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("CurrentPlayer", this.CurrentPlayer);
            info.AddValue("Board", this.Board);
            info.AddValue("Dice", this.Dice);
            info.AddValue("Players", this.Players);
            info.AddValue("ResourceDeck", this.ResourceDeck);
            info.AddValue("ResourceLookup", this.ResourceLookup);
            info.AddValue("DevelopmentDeck", this.DevelopmentDeck);
            info.AddValue("LongestRoad", this.LongestRoad);
            info.AddValue("LargestArmy", this.LargestArmy);
            info.AddValue("LongestRoadLength", this.LongestRoadLength);
        }

        public void Save(string fileName)
        {
            Serializer temp = new Serializer();
            temp.Save(this, fileName);
        }

        public GameController()
        {
            Dice = new Dice();
            Players = new ArrayList();
            Board = new Board();
            InitializeResourceLookup();
            InitializeResourceDeck();
            InitializeDevelopmentDeck();
        }

        public GameController(ArrayList players)
        {
            Dice = new Dice();
            Players = players;
            CurrentPlayer = (Player) Players[0];
            Board = new Board();
            InitializeResourceLookup();
            InitializeResourceDeck();
            InitializeDevelopmentDeck();
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

            DevelopmentDeck = new ArrayList();
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

            var ret = (CardType) DevelopmentDeck[0];
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
            var armies = CountArmies();
            var armyToBeat = 2;
            if (LargestArmy != null)
            {
                armyToBeat = armies[LargestArmy];
            }

            foreach(Player player in Players)
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
                var sets = PartitionRoads(player);
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

        private int FindLongestRoadInSet(List<List<Road>> sets)
        {
            var longest = 0;

            foreach (List<Road> road in sets)
            {
                var endPoints = FindEndPoints(road);
                foreach (Road endPoint in endPoints)
                {
                    ResetRoadMarks();
                    var curRoad = MeasureRoad(endPoint, 0);
                    if (curRoad > longest)
                    {
                        longest = curRoad;
                    }
                }
            }

            return longest;
        }

        private int MeasureRoad(Road curRoad, int length)
        {
            curRoad.Marked = true;

            var bestSoFar = 0;
            foreach (int index in curRoad.Indices)
            {
                var vertex = (Vertex) Board.Vertices[index];
                foreach (Road nextRoad in vertex.Roads)
                {
                    if (nextRoad != null && !nextRoad.Marked && nextRoad.player == curRoad.player)
                    {
                        var thisPath = MeasureRoad(nextRoad, length + 1);
                        if (thisPath > bestSoFar)
                        {
                            bestSoFar = thisPath;
                        }
                    }
                }
            }

            return bestSoFar + 1;
        }

        private List<Road> FindEndPoints(List<Road> road)
        {
            var endPoints = new List<Road>();

            foreach (Road roadPiece in road)
            {
                var vertex1 = (Vertex) Board.Vertices[roadPiece.Indices[0]];
                var vertex2 = (Vertex) Board.Vertices[roadPiece.Indices[1]];

                var endFlag = true;
                for (int i = 0; i < 3; i++)
                {
                    if (vertex1.Roads[i] != null && vertex1.Roads[i] != roadPiece)
                    {
                        if (((Road) vertex1.Roads[i]).player == roadPiece.player)
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

                endFlag = true;
                for (int i = 0; i < 3; i++)
                {
                    if (vertex2.Roads[i] != null && vertex2.Roads[i] != roadPiece)
                    {
                        if (((Road) vertex2.Roads[i]).player == roadPiece.player)
                        {
                            endFlag = false;
                            break;
                        }
                    }
                }

                if (endFlag)
                {
                    endPoints.Add(roadPiece);
                }
            }

            return new List<Road>(new[] {road[0]});
        }

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

        private List<Road> TraverseRoad(Road road, Player player, List<Road> list)
        {
            list.Add(road);
            road.Marked = true;

            foreach (int i in road.Indices)
            {
                var vertex = (Vertex)Board.Vertices[i];
                for (int j=0; j<3; j++)
                {
                    var nextRoad = (Road)vertex.Roads[j];
                    if (nextRoad != null && !nextRoad.Marked && nextRoad.player == player && (vertex.Settlement == null || vertex.Settlement.player == player))
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
                CurrentPlayer = (Player) Players[index + 1];
            }
            else
            {
                CurrentPlayer = (Player) Players[0];
            }
        }

        //Grants a resource for each settlement adjacent
        //to the hex with the number rolled
        public void AwardResourceForSettlementAdjacentToRolledHex()
        {
            foreach (Tile tile in Board.TerrainTiles)
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
                                    DrawResource((SettlersOfCatan.TileType) tile.Type));
                            }
                            else if (vertex.Settlement.type == SettlementType.City)
                            {
                                vertex.Settlement.player.ResourceHand.Add(
                                    DrawResource((SettlersOfCatan.TileType)tile.Type));
                                vertex.Settlement.player.ResourceHand.Add(
                                    DrawResource((SettlersOfCatan.TileType)tile.Type));
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
                    int numberToRemove = (count % 2 == 0) ? count / 2 : (count - 1) / 2;
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
    }

    public class EmptyDeckException : Exception
    {
    }
}