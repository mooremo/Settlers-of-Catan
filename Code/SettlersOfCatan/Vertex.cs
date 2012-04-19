using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class Vertex
    {
        //Neighbors are indexed in a clockwise fashion
        public ArrayList neighbors { get; set; }
        public ArrayList roads { get; set; }
        public Settlement settlement { get; set; }

        public Vertex()
        {

        }

        public bool playerCanBuildSettlement(Player player)
        {
            if (settlement != null  && settlement.player != player && settlement.type != SettlementType.Village)
            {
                return false;
            }
            int size = roads.Count;
            Road checkRoad;
            for (int i = 0; i < size; i++)
            {
                if (roads[i] == null)
                {
                    continue;
                }
                checkRoad = (Road) roads[i];
                if (checkRoad.player == player)
                {
                    return true;
                }
            }
            return false;
        }

        public bool playerCanBuildRoad(Player player)
        {
            int size = roads.Count;
            Road checkRoad;
            int roadCount = 0;
            bool flag = false;
            for (int i = 0; i < size; i++)
            {
                if (roads[i] == null)
                {
                    continue;
                }
                checkRoad = (Road)roads[i];
                if (checkRoad.player == player)
                {
                    flag = true;
                    roadCount++;
                }
            }
            return ((roadCount < 3) && flag);
        }
    }
}
