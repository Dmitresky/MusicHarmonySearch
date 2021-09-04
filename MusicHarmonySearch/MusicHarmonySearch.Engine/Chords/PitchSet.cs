using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MusicHarmonySearch.Engine.Chords
{
    public class PitchSet : IEnumerable<Pitch>
    {
        private readonly Pitch[] _pitches;
        private readonly Pitch[] _packedPitches;

        public static PitchSet Create(params string[] pitchRecords)
        {
            Pitch[] notes = new Pitch[pitchRecords.Length];

            for (int i = 0; i < pitchRecords.Length; i++)
            {
                notes[i] = Pitch.Create(pitchRecords[i]);
            }

            return Create(notes);
        }

        public static PitchSet Create(params Pitch[] pitches)
        {
            pitches = pitches.OrderBy(x => x).ToArray();
            var packed = Pack(pitches);

            return new PitchSet(pitches, packed);
        }

        private PitchSet(Pitch[] notes, Pitch[] packed)
        {
            _pitches = notes;
            _packedPitches = packed;
        }

        internal int Length => _pitches.Length;

        public static Pitch[] Pack(params Pitch[] notes)
        {
            HashSet<Pitch> pitchHash = new HashSet<Pitch>();

            pitchHash.Add(notes[0]);

            Pitch previous = notes[0];
            Pitch current = null;

            for (int i = 1; i < notes.Length; i++)
            {
                current = notes[i];
                while (current.GetSemitones() - 12 >= previous.GetSemitones())
                {
                    current = current.DownOnOctave();
                }

                pitchHash.Add(current);
            }

            return pitchHash.ToArray();
        }

        public IEnumerator<Pitch> GetEnumerator()
        {
            foreach (var note in _pitches)
            {
                yield return note;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PitchSet);
        }

        public bool Equals(PitchSet other)
        {
            if (other == null)
            {
                return false;
            }

            if (!_pitches.SequenceEqual(other._pitches))
            {
                return false;
            }

            if (!_packedPitches.SequenceEqual(other._packedPitches))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Pitch this[int index]
        {
            get => _pitches[index];
        }

        public IReadOnlyList<Pitch> Packed
        {
            get
            {
                return this._packedPitches;
            }
        }
    }
}
