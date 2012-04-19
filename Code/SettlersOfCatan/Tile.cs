using System.Collections;

namespace SettlersOfCatan
{
    public class Tile
    {
        //Neighbors are indexed in a clockwise fashion
        public int type { get; set; }
        public int number { get; set; }
        public ArrayList neighbors { get; set; }
    }
}