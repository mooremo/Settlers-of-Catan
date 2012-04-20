using System.Collections;

namespace SettlersOfCatan
{
    public class Vertex
    {
        //Neighbors are indexed in a clockwise fashion
        public ArrayList Neighbors { get; set; }
        public ArrayList Roads { get; set; }
        public Settlement Settlement { get; set; }

        public Vertex()
        {
            Neighbors = new ArrayList();
            Roads = new ArrayList();
        }

        public bool PlayerCanBuildSettlement(Player player)
        {
            if (Settlement != null && Settlement.player != player && Settlement.type != SettlementType.Village)
            {
                return false;
            }
            int size = Roads.Count;
            Road checkRoad;
            for (int i = 0; i < size; i++)
            {
                if (Roads[i] == null)
                {
                    continue;
                }
                checkRoad = (Road) Roads[i];
                if (checkRoad.player == player)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PlayerCanBuildRoad(Player player)
        {
            int size = Roads.Count;
            Road checkRoad;
            int roadCount = 0;
            bool flag = false;
            for (int i = 0; i < size; i++)
            {
                if (Roads[i] == null)
                {
                    continue;
                }
                checkRoad = (Road) Roads[i];
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