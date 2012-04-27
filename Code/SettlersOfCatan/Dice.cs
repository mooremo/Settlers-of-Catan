using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SettlersOfCatan
{
    [Serializable]
    public class Dice : ISerializable
    {
        public ArrayList Two6Sided = new ArrayList(new int[] { 2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 11, 11, 12 });
        public int Value;

     public Dice(SerializationInfo info, StreamingContext ctxt)
       {
           this.Two6Sided = (ArrayList)info.GetValue("Two6Sided", typeof(ArrayList));
           this.Value = (int)info.GetValue("Value", typeof(int));
       }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Two6Sided", this.Two6Sided);
            info.AddValue("Value", this.Value);
        }


        public Dice()
        {
            this.Roll();
        }

        public int Roll()
        {
            Shuffler.Shuffle(Two6Sided);
            Value = (int) Two6Sided[0];
            return Value;
        }
    }
}