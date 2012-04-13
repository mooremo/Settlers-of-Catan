using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfCatan;

namespace SettlersOfCatan
{
    public class Settlement
    {
        public SettlementType type { get; set; }
        public Player player { get; set; }

        public Settlement(Player player, SettlementType settlementType)
        {
            // TODO: Complete member initialization
            this.player = player;
            this.type = settlementType;
        }
    }
}
