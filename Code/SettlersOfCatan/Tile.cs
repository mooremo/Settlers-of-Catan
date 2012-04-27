using System.Collections;

namespace SettlersOfCatan
{
    public class Tile
    {
        //Neighbors are indexed in a clockwise fashion
        public Tile(int iType)
        {
            Type = iType;
        }

        public Tile(int iType, int iNum)
        {
            Type = iType;
            Number = iNum;
        }

        public int Type { get; set; }
        public int Number { get; set; }
        public ArrayList Neighbors { get; set; }
        public ArrayList Vertices { get; set; }
        public bool Robber { get; set; }
    }
}