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
            Players = new ArrayList();
            InitializeResourceLookup();
            InitializeResourceDeck();
            InitializeDevelopmentDeck();
        }

        public GameController(ArrayList players)
        {
            Players = players;
            CurrentPlayer = (Player) Players[0];
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
            foreach (Vertex vertex in Board.Vertices)
            {
                for (int i=0; i<3; i++)
                {
                    var road = vertex.Roads[i];
                    if (road != null)
                    {
                       
                    }
                }
            }
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
    }

    public class EmptyDeckException : Exception
    {
    }
}