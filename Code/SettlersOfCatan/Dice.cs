using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    [Serializable]
    public class Dice : ISerializable
    {
        public List<int> Two6Sided =
            new List<int>(new int[]
                              {
                                  2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 9, 9, 9, 9,
                                  10, 10, 10, 11, 11, 12
                              });

        public int Value;

        public Dice(SerializationInfo info, StreamingContext ctxt)
        {
            Two6Sided = (List<int>) info.GetValue("Two6Sided", typeof (List<int>));
            Value = (int) info.GetValue("Value", typeof (int));
        }


        public Dice()
        {
            Roll();
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Two6Sided", Two6Sided);
            info.AddValue("Value", Value);
        }

        #endregion

        public int Roll()
        {
            Shuffler.Shuffle(Two6Sided);
            Value = (int) Two6Sided[0];
            return Value;
        }
    }
}