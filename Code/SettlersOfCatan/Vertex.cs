using System;
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
            Neighbors = new List<Vertex>(new Vertex[] {null, null, null});
            Roads = new List<Road>(new Road[] {null, null, null});
        }

        public int Index { get; set; }
        public List<Vertex> Neighbors { get; set; }
        public List<Road> Roads { get; set; }
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

        public bool HasRoad(Vertex other)
        {
            var index = Neighbors.IndexOf(other);

            if (index < 0)
            {
                throw new Exception("Given vertex is not a neighbor of this vertex");
            }

            return Roads[index] != null;
        }
    }
}