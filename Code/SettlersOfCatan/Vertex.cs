using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    public class Vertex
    {
        //Neighbors are indexed in a clockwise fashion
        public Vertex(int i)
        {
            Index = i;
            Neighbors = new List<Vertex>();
            Roads = new List<Road>(3);
        }

        public Vertex(SerializationInfo info, StreamingContext ctxt)
        {
            Index = (int) info.GetValue("Index", typeof (int));
            Neighbors = (List<Vertex>) info.GetValue("Neighbors", typeof (List<Vertex>));
            Roads = (List<Road>) info.GetValue("Roads", typeof (List<Road>));
            Settlement = (Settlement) info.GetValue("Robber", typeof (Settlement));
        }

        public int Index { get; set; }
        public List<Vertex> Neighbors { get; set; }
        public List<Road> Roads { get; set; }
        public Settlement Settlement { get; set; }


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Index", Index);
            info.AddValue("Roads", Roads);
            info.AddValue("Neighbors", Neighbors);
            info.AddValue("Settlement", Settlement);
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
                checkRoad = Roads[i];
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
                    checkRoad = Roads[i];
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