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
            resourceLookup = new Dictionary<TileType, CardType>();
            resourceLookup.Add(TileType.Fields, CardType.Grain);
            resourceLookup.Add(TileType.Woods, CardType.Lumber);
            resourceLookup.Add(TileType.Hills, CardType.Brick);
            resourceLookup.Add(TileType.Mountains, CardType.Ore);
            resourceLookup.Add(TileType.Pasture, CardType.Wool);
        }

        private void InitializeResourceDeck()
        {
            resourceDeck = new Dictionary<TileType, int>();
            resourceDeck.Add(TileType.Fields, 19);
            resourceDeck.Add(TileType.Woods, 19);
            resourceDeck.Add(TileType.Hills, 19);
            resourceDeck.Add(TileType.Mountains, 19);
            resourceDeck.Add(TileType.Pasture, 19);
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
            throw new NotImplementedException();
        }
    }

    public class EmptyDeckException : Exception
    {
    }
}