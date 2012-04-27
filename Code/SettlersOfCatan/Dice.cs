using System;
using System.Collections;
using System.Collections.Generic;

namespace SettlersOfCatan
{
    public class Dice
    {
        public ArrayList Two6Sided = new ArrayList(new int[] {2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 11, 11, 12});
        public int Value;

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