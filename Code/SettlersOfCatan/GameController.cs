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
        public Dictionary<int, int> resourceDeck { get; set; }
        public ArrayList developmentDeck { get; set; }
        public Player longestRoad { get; set; }
        public Player largestArmy { get; set; }

        public GameController()
        { 

        }
    }
}
