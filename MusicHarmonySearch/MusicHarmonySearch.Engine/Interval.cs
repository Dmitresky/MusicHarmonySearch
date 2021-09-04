using MusicHarmonySearch.Engine.Catalogs;
using System;

namespace MusicHarmonySearch.Engine
{
    public class Interval
    {
        private Pitch _note1;
        private Pitch _note2;
        private Intervals _interval;

        private Interval(Pitch note1, Pitch note2, Intervals interval)
        {
            this._note1 = note1;
            this._note2 = note2;
            this._interval = interval;
        }

        public Intervals Value {
            get
            {
                return this._interval;
            }
        }

        public static Interval Get(Pitch pitch1, Pitch pitch2)
        {
            Pitch lower = pitch1;
            Pitch higher = pitch2;

            if (pitch1.GetSemitones() > pitch2.GetSemitones())
            {
                lower = pitch2;
                higher = pitch1;
            }

            var numberInterval = Interval.GetNumberInterval(lower.Note.GetTone(), higher.Note.GetTone());
            var countSemitones = Math.Abs(pitch1.GetSemitones() - pitch2.GetSemitones());

            return new Interval(lower, higher, IntervalStore.GetInterval(numberInterval, countSemitones));
        }

        public static NumberIntervals GetNumberInterval(Notes lower, Notes higher)
        {
            int h = (int)higher;
            int l = (int)lower;

            if (h < l)
            {
                h += 7;
            }

            return (NumberIntervals) h - l + 1;
        }

        public override string ToString()
        {
            return Value.ToString();
        }


    }
}