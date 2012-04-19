using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class GameController
    {
        public Board board { get; set; }
        public Dice dice { get; set; }
        public ArrayList Players { get; set; }
        public Dictionary<TileType, int> resourceDeck { get; set; }
        public Dictionary<TileType, CardType> resourceLookup { get; set; } 
        public ArrayList developmentDeck { get; set; }
        public Player longestRoad { get; set; }
        public Player largestArmy { get; set; }

        public GameController()
        { 

        }

        private void InitializeResourceLookup()
        {
            resourceLookup[TileType.Fields] = CardType.Grain;
            resourceLookup[TileType.Hills] = CardType.Brick;
            resourceLookup[TileType.Woods] = CardType.Lumber;
            resourceLookup[TileType.Mountains] = CardType.Ore;
            resourceLookup[TileType.Pasture] = CardType.Wool;
        }

        private void InitializeResourceDeck()
        {
            resourceDeck[TileType.Fields] = 19;
            resourceDeck[TileType.Hills] = 19;
            resourceDeck[TileType.Woods] = 19;
            resourceDeck[TileType.Mountains] = 19;
            resourceDeck[TileType.Pasture] = 19;
        }

        public CardType DrawResource(TileType tile)
        {
            if (resourceDeck[tile] <= 0)
            {
                return null;
            }

            resourceDeck[tile] -= 1;
            return resourceLookup[tile];

        }

        public CardType DrawDevelopment()
        {
            throw new NotImplementedException();
        }
    }
}
