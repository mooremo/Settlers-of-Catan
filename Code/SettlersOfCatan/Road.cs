using System;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    public class Road
    {
        public Road(Player player)
        {
            // TODO: Complete member initialization
            this.player = player;
            Indices = new int[2];
            Marked = false;
        }

        public Road(SerializationInfo info, StreamingContext ctxt)
        {
            player = (Player) info.GetValue("TerrainTiles", typeof (Player));
            Indices = (int[]) info.GetValue("PortTiles", typeof (int[]));
            Marked = (bool) info.GetValue("Vertices", typeof (bool));
        }

        public Player player { get; set; }
        public int[] Indices { get; set; }
        public bool Marked { get; set; }


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("player", player);
            info.AddValue("Indices", Indices);
            info.AddValue("Marked", Marked);
        }

        public void SetIndices(int x, int y)
        {
            Indices[0] = Math.Min(x, y);
            Indices[1] = Math.Max(x, y);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Road))
            {
                return false;
            }
            else
            {
                var o = obj as Road;
                return o.Indices[0] == Indices[0] && o.Indices[1] == Indices[1] && o.player == player;
            }
        }

        public override int GetHashCode()
        {
            return Indices[0] ^ Indices[1];
        }
    }
}