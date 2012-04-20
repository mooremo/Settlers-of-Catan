using System;
using System.Collections;
using System.Collections.Generic;

namespace SettlersOfCatan
{
    public class GameController
    {
        public GameController()
        {
            InitializeResourceLookup();
            InitializeResourceDeck();
            InitializeDevelopmentDeck();
        }

        public GameController(ArrayList players)
        {
            Players = players;
            CurrentPlayer = (Player)Players[0];
            InitializeResourceLookup();
            InitializeResourceDeck();
            InitializeDevelopmentDeck();
        }

        public Board Board { get; set; }
        public Dice Dice { get; set; }
        public ArrayList Players { get; set; }
        public Dictionary<TileType, int> ResourceDeck { get; set; }
        public Dictionary<TileType, CardType> ResourceLookup { get; set; }
        public ArrayList DevelopmentDeck { get; set; }
        public Player LongestRoad { get; set; }
        public Player LargestArmy { get; set; }
        public Player CurrentPlayer;

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
                                           {CardType.Solider, 14},
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
    }

    public class EmptyDeckException : Exception
    {
    }
}