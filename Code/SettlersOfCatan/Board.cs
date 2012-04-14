using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class Board
    {
        public Map<Tile> tiles { get; set; }
        public Map<Vertex> vertices { get; set; }

        public Board()
        {
            
        }
    }
}
