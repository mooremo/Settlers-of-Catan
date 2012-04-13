using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SettlersOfCatan
{
    public class Player
    {
        public String name { get; set; }
        public int color { get; set; }
        public ArrayList resourceHand { get; set; }
        public ArrayList developmentHand { get; set; }
        public int roadsRemaining { get; set; }
        public int villagesRemaining { get; set; }
        public int citiesRemaining { get; set; }
        public int score { get; set; }

        public Player()
        {

        }
    }
}
