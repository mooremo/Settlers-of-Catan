using System;

namespace SettlersOfCatan
{
    public class Road
    {
        public Road(Player player)
        {
            // TODO: Complete member initialization
            this.player = player;
            this.Indices = new int[2];
            this.Marked = false;
        }

        public void SetIndices(int x, int y)
        {
            Indices[0] = Math.Min(x, y);
            Indices[1] = Math.Max(x, y);
        }

        public Player player { get; set; }
        public int[] Indices { get; set; }
        public bool Marked { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Road))
            {
                return false;
            } else
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