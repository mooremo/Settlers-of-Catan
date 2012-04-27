using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SettlersOfCatan
{
    [Serializable]
    public class Dice : ISerializable
    {
             public Dice(SerializationInfo info, StreamingContext ctxt)
       {
       }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
        }
    }
}