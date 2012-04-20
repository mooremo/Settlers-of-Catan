using System.Collections;

namespace SettlersOfCatan
{
    public class Vertex
    {
        //Neighbors are indexed in a clockwise fashion
        public Vertex()
        {
            Neighbors = new ArrayList();
            Roads = new ArrayList(new Road[] {null, null, null});
        }

        public ArrayList Neighbors { get; set; }
        public ArrayList Roads { get; set; }
        public Settlement Settlement { get; set; }

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
                if (Roads[i] != null)
                {
                    checkRoad = (Road) Roads[i];
                    if (checkRoad.player == player)
                    {
                        flag = true;
                    }
                    roadCount++;
                }
            }
            return ((roadCount < 3) && (flag || (Settlement != null && Settlement.player == player)));
        }
    }
}