using MusicHarmonySearch.Engine.Catalogs;
using MusicHarmonySearch.Engine.Chords.Inversions;
using MusicHarmonySearch.Engine.Chords.Sevenths;
using MusicHarmonySearch.Engine.Chords.Triad.Roots;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicHarmonySearch.Engine.Chords
{
    public abstract class Chord : IEquatable<Chord>
    {
        private Inversion _inversion;
        protected string Postfix;

        public static Chord Create(params string[] noteRecords)
        {
            Pitch[] notes = new Pitch[noteRecords.Length];

            for (int i = 0; i < noteRecords.Length; i++)
            {
                notes[i] = Pitch.Create(noteRecords[i]);
            }

            return Create(notes.OrderBy(x => x).ToArray());
        }

        public static Chord Create(params Pitch[] pitches)
        {
            if (pitches == null || pitches.Length == 0)
            {
                throw new ArgumentNullException(nameof(pitches));
            }

            if (pitches.Length < 3)
            {
                throw new ArgumentException(nameof(pitches));
            }

            var noteSet = PitchSet.Create(pitches);

            switch (noteSet.Packed.Count())
            {
                case 3:
                    return CreateTriad(noteSet);
                case 4:
                    return CreateSeventh(noteSet);
                default:
                    throw new ArgumentException("Too match notes for creating chord");
                    break;
            }
        }

        private static Chord CreateTriad(PitchSet noteSet)
        {
            var interval1 = Interval.Get(noteSet.Packed[0], noteSet.Packed[1]);
            var interval2 = Interval.Get(noteSet.Packed[1], noteSet.Packed[2]);

            return (interval1.Value, interval2.Value) switch
            {
                (Intervals.M3, Intervals.m3) => new Major(new NoInversion(noteSet)),
                (Intervals.m3, Intervals.P4) => new Major(new FirstInversion(noteSet)),
                (Intervals.P4, Intervals.M3) => new Major(new SecondInversion(noteSet)),
                (Intervals.m3, Intervals.M3) => new Minor(new NoInversion(noteSet)),
                (Intervals.M3, Intervals.P4) => new Minor(new FirstInversion(noteSet)),
                (Intervals.P4, Intervals.m3) => new Minor(new SecondInversion(noteSet)),
                (Intervals.M3, Intervals.M3) => new Augmented(new NoInversion(noteSet)),
                (Intervals.M3, Intervals.d4) => new Augmented(new FirstInversion(noteSet)),
                (Intervals.d4, Intervals.M3) => new Augmented(new SecondInversion(noteSet)),
                (Intervals.m3, Intervals.m3) => new Diminished(new NoInversion(noteSet)),
                (Intervals.m3, Intervals.A4) => new Diminished(new FirstInversion(noteSet)),
                (Intervals.A4, Intervals.m3) => new Diminished(new SecondInversion(noteSet)),
                _ => throw new ArgumentException($"Can't specify a chord by intervals: {interval1.Value}, {interval2.Value}")
            };
        }

        public string GetMainNote()
        {
            return _inversion.GetMainNote();
        }

        public string GetBase()
        {
            return _inversion.GetBase();
        }

        public string GetName()
        {
            return _inversion.GetName(Postfix);
        }

        private static Chord CreateSeventh(PitchSet noteSet)
        {
            var interval1 = Interval.Get(noteSet.Packed[0], noteSet.Packed[1]);
            var interval2 = Interval.Get(noteSet.Packed[1], noteSet.Packed[2]);
            var interval3 = Interval.Get(noteSet.Packed[2], noteSet.Packed[3]);

            return (interval1.Value, interval2.Value, interval3.Value) switch
            {
                (Intervals.M3, Intervals.m3, Intervals.m3) => new DominantSeventh(new NoInversion(noteSet)),
                (Intervals.m3, Intervals.m3, Intervals.M2) => new DominantSeventh(new FirstInversion(noteSet)),
                (Intervals.m3, Intervals.M2, Intervals.M3) => new DominantSeventh(new SecondInversion(noteSet)),
                (Intervals.M2, Intervals.M3, Intervals.m3) => new DominantSeventh(new ThirdInversion(noteSet)),
                (Intervals.m3, Intervals.M3, Intervals.m3) => new MinorSeventh(new NoInversion(noteSet)),
                (Intervals.M3, Intervals.m3, Intervals.M2) => new MinorSeventh(new FirstInversion(noteSet)),
                (Intervals.m3, Intervals.M2, Intervals.m3) => new MinorSeventh(new SecondInversion(noteSet)),
                (Intervals.M2, Intervals.m3, Intervals.M3) => new MinorSeventh(new ThirdInversion(noteSet)),
                (Intervals.M3, Intervals.M3, Intervals.m3) => new AugmentedMajorSeventh(new NoInversion(noteSet)),
                (Intervals.M3, Intervals.m3, Intervals.m2) => new AugmentedMajorSeventh(new FirstInversion(noteSet)),
                (Intervals.m3, Intervals.m2, Intervals.M3) => new AugmentedMajorSeventh(new SecondInversion(noteSet)),
                (Intervals.m2, Intervals.M3, Intervals.M3) => new AugmentedMajorSeventh(new ThirdInversion(noteSet)),
                (Intervals.m3, Intervals.m3, Intervals.m3) => new DiminishedSeventh(new NoInversion(noteSet)),
                (Intervals.m3, Intervals.m3, Intervals.A2) => new DiminishedSeventh(new FirstInversion(noteSet)),
                (Intervals.m3, Intervals.A2, Intervals.m3) => new DiminishedSeventh(new SecondInversion(noteSet)),
                (Intervals.A2, Intervals.m3, Intervals.m3) => new DiminishedSeventh(new ThirdInversion(noteSet)),
                _ => throw new ArgumentException($"Can't specify a seventh chord by intervals: {interval1.Value}, {interval2.Value}, {interval3.Value}")
            };
        }

        protected Chord(Inversion inversion)
        {
            _inversion = inversion;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Chord);
        }

        public bool Equals(Chord other)
        {
            if (other == null)
            {
                return false;
            }

            return _inversion == other._inversion;
        }


        public IEnumerable<Pitch> GetNotes()
        {
            return _inversion.GetNotes();
        }

        public static bool operator ==(Chord left, Chord right)
        {
            return EqualityComparer<Chord>.Default.Equals(left, right);
        }

        public static bool operator !=(Chord left, Chord right)
        {
            return !(left == right);
        }
    }
}