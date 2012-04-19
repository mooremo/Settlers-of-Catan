using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class Board
    {
        public ArrayList tiles { get; set; }
        public ArrayList vertices { get; set; }

        //All tiles know their neighbors and all vertices know neighbors
        public Board()
        {
            tiles = new ArrayList(21);
            vertices = new ArrayList();

            return this;
        }

        public Board generateBoard()
        {
            return board;
        }
    }
}
