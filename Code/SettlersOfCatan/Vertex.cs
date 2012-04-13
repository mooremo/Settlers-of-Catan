using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class Vertex
    {
        public ArrayList neighbors { get; set; }
        public ArrayList roads { get; set; }
        public Settlement settlement { get; set; }

        public Vertex()
        {

        }
    }
}
