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
        public int Type { get; set; }
        public int Number { get; set; }
        public ArrayList Neighbors { get; set; }
        public ArrayList Vertices { get; set; }

        public Tile(int iType)
        {
            Type = iType;
        }

        public Tile(int iType, int iNum)
        {
            Type = iType;
            Number = iNum;
        }
    }
}
