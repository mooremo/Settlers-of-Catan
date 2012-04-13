using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class Board
    {
        public Graph<Tile> tiles { get; set; }
        public Graph<Vertex> vertices { get; set; }

        public Board()
        {
            
        }
    }
}
