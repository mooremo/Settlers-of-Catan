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

        public Board board { get; set; }
        public Dice dice { get; set; }
        public ArrayList Players { get; set; }
        public Dictionary<TileType, int> resourceDeck { get; set; }
        public Dictionary<TileType, CardType> resourceLookup { get; set; }
        public ArrayList developmentDeck { get; set; }
        public Player longestRoad { get; set; }
        public Player largestArmy { get; set; }

        private void InitializeResourceLookup()
        {
            resourceLookup = new Dictionary<TileType, CardType>
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
            resourceDeck = new Dictionary<TileType, int>
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
            
            developmentDeck = new ArrayList();
            foreach (CardType card in developmentCount.Keys)
            {
                for (int i=0; i<developmentCount[card]; i++)
                {
                    developmentDeck.Add(card);
                }
            }

            Shuffler.Shuffle(developmentDeck);
        }

        public CardType DrawResource(TileType tile)
        {
            if (resourceDeck[tile] <= 0)
            {
                throw new EmptyDeckException();
            }

            resourceDeck[tile] -= 1;
            return resourceLookup[tile];
        }

        public CardType DrawDevelopment()
        {
            if (developmentDeck.Count == 0)
            {
                throw new EmptyDeckException();
            }

            var ret = (CardType)developmentDeck[0];
            developmentDeck.RemoveAt(0);
            return ret;
        }
    }

    public class EmptyDeckException : Exception
    {
    }
}