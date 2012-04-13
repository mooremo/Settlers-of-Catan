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
        public ArrayList developmentDeck { get; set; }
        public Player longestRoad { get; set; }
        public Player largestArmy { get; set; }

        public GameController()
        { 

        }

        public CardType DrawResource(TileType tile)
        {
            throw new NotImplementedException();
        }

        public CardType DrawDevelopment()
        {
            throw new NotImplementedException();
        }
    }
}
