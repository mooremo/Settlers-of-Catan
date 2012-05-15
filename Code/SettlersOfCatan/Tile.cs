using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    public class Tile
    {
        //Neighbors are indexed in a clockwise fashion
        public Tile(TileType iType)
        {
            Type = iType;
        }

        public Tile(int iType)
        {
            Type = (TileType) iType;
        }

        public Tile(TileType iType, int iNum)
        {
            Type = iType;
            Number = iNum;
        }

        public TileType Type { get; set; }
        public int Number { get; set; }
        public List<Tile> Neighbors { get; set; }
        public List<Vertex> Vertices { get; set; }
        public bool Robber { get; set; }
    }
}