using System;
using System.Collections.Generic;

namespace MusicHarmonySearch.Engine.Catalogs
{
    public static class IntervalStore
    {
        private static Dictionary<NumberIntervals, Dictionary<int, Intervals>> intervalDictionary = new Dictionary<NumberIntervals, Dictionary<int, Intervals>>();

        static IntervalStore()
        {
            var primeOrOctave = new Dictionary<int, Intervals>();
            primeOrOctave.Add(0, Intervals.P1);
            primeOrOctave.Add(1, Intervals.A1);
            primeOrOctave.Add(11, Intervals.d8);
            primeOrOctave.Add(12, Intervals.P8);
            intervalDictionary.Add(NumberIntervals.Prime, primeOrOctave);

            var second = new Dictionary<int, Intervals>();
            second.Add(0, Intervals.d2);
            second.Add(1, Intervals.m2);
            second.Add(2, Intervals.M2);
            second.Add(3, Intervals.A2);
            intervalDictionary.Add(NumberIntervals.Second, second);

            var third = new Dictionary<int, Intervals>();
            third.Add(2, Intervals.d3);
            third.Add(3, Intervals.m3);
            third.Add(4, Intervals.M3);
            third.Add(5, Intervals.A3);
            intervalDictionary.Add(NumberIntervals.Third, third);


            var forth = new Dictionary<int, Intervals>();
            forth.Add(4, Intervals.d4);
            forth.Add(5, Intervals.P4);
            forth.Add(6, Intervals.A4);
            intervalDictionary.Add(NumberIntervals.Fourth, forth);

            var fifth = new Dictionary<int, Intervals>();
            fifth.Add(6, Intervals.d5);
            fifth.Add(7, Intervals.P5);
            fifth.Add(8, Intervals.A5);
            intervalDictionary.Add(NumberIntervals.Fifth, fifth);

            var sixth = new Dictionary<int, Intervals>();
            sixth.Add(7, Intervals.d6);
            sixth.Add(8, Intervals.m6);
            sixth.Add(9, Intervals.M6);
            sixth.Add(10, Intervals.A6);
            intervalDictionary.Add(NumberIntervals.Sixth, sixth);

            var seventh = new Dictionary<int, Intervals>();
            seventh.Add(9, Intervals.d7);
            seventh.Add(10, Intervals.m7);
            seventh.Add(11, Intervals.M7);
            seventh.Add(12, Intervals.A7);
            intervalDictionary.Add(NumberIntervals.Seventh, seventh);
        }

        public static Intervals GetInterval(NumberIntervals numberInterval, int countSemitones)
        {
            try
            {
                return intervalDictionary[numberInterval][countSemitones];
            }
            catch
            {
                throw new ArgumentException($"Can't specify interval. Expected {numberInterval} with {countSemitones} semitones");
            }
        }
    }
}
