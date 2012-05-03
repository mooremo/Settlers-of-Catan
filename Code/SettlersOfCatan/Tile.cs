using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    public class Tile
    {
        //Neighbors are indexed in a clockwise fashion
        public Tile(int iType)
        {
            Type = iType;
        }

        public Tile(int iType, int iNum)
        {
            Type = iType;
            Number = iNum;
        }

        public Tile(SerializationInfo info, StreamingContext ctxt)
        {
            Type = (int) info.GetValue("type", typeof (int));
            Number = (int) info.GetValue("Number", typeof (int));
            Neighbors = (List<Tile>) info.GetValue("Neighbors", typeof (List<Tile>));
            Vertices = (List<Vertex>) info.GetValue("Vertices", typeof (List<Vertex>));
            Robber = (bool) info.GetValue("Robber", typeof (bool));
        }

        public int Type { get; set; }
        public int Number { get; set; }
        public List<Tile> Neighbors { get; set; }
        public List<Vertex> Vertices { get; set; }
        public bool Robber { get; set; }


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("type", Type);
            info.AddValue("Number", Number);
            info.AddValue("Neighbors", Neighbors);
            info.AddValue("Vertices", Vertices);
            info.AddValue("Robber", Robber);
        }
    }
}