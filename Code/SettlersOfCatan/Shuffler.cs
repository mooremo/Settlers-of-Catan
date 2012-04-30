using System;
using System.Collections;
using System.Collections.Generic;

namespace SettlersOfCatan
{
    internal class Shuffler
    {
        public static void Shuffle(List<int> source)
        {
            var rnd = new Random();
            for (int inx = source.Count - 1; inx > 0; --inx)
            {
                int position = rnd.Next(inx);
                int temp = source[inx];
                source[inx] = source[position];
                source[position] = temp;
            }
        }

        public static void Shuffle(ArrayList source)
        {
            var rnd = new Random();
            for (int inx = source.Count - 1; inx > 0; --inx)
            {
                int position = rnd.Next(inx);
                var temp = source[inx];
                source[inx] = source[position];
                source[position] = temp;
            }
        }

        public static void Shuffle(List<CardType> source)
        {
            var rnd = new Random();
            for (int inx = source.Count - 1; inx > 0; --inx)
            {
                int position = rnd.Next(inx);
                CardType temp = source[inx];
                source[inx] = source[position];
                source[position] = temp;
            }
        }
    }
}