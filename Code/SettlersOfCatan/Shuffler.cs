using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    class Shuffler
    {
        public static void Shuffle(ArrayList source)
        {
            var rnd = new Random();
            for (int inx = source.Count - 1; inx > 0; --inx)
            {
                int position = rnd.Next(inx);
                object temp = source[inx];
                source[inx] = source[position];
                source[position] = temp;
            }

        }
    }
}
