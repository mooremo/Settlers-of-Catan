using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class Tile
    {
        //Neighbors are indexed in a clockwise fashion
        public int type { get; set; }
        public int number { get; set; }
        public ArrayList neighbors { get; set; }

        public Tile()
        {

        }
    }
}
