using System;
using System.Collections;

namespace SettlersOfCatan
{
    public class Player
    {
        public String Name { get; set; }
        public int Color { get; set; }
        public ArrayList ResourceHand { get; set; }
        public ArrayList DevelopmentHand { get; set; }
        public int RoadsRemaining { get; set; }
        public int VillagesRemaining { get; set; }
        public int CitiesRemaining { get; set; }
        public int Score { get; set; }

        public Player()
        {
            
        }

        public Player(String name)
        {
            Name = name;
        }

        public void EndTurn()
        {
            
        }
    }
}