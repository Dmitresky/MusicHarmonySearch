using MusicHarmonySearch.Engine.Catalogs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MusicHarmonySearch.Engine
{
    public class Pitch : IEquatable<Pitch>, IComparable<Pitch>
    {
        private Note _note;
        private int _octave;
        private int _semetones;

        public Note Note { get
            {
                return _note;
            } }

        public string GetNote()
        {
            return _note.ToString();
        }

        private Pitch(Note note, int octava)
        {
            _note = note;
            _octave = octava;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Pitch);
        }

        public bool Equals(Pitch other)
        {
            return other != null &&
                   _note == other._note &&
                   _octave == other._octave;
        }

        public int GetSemitones()
        {
            int semitones = 0;
            if (_octave == 0)
            {
                semitones = (int)_note.GetNoteSemitons() - 9;
            }
            else
            {
                semitones = 12 * (_octave - 1) + (int)_note.GetNoteSemitons() + 3;
            }

            return semitones;
        }

        public static bool operator ==(Pitch left, Pitch right)
        {
            return EqualityComparer<Pitch>.Default.Equals(left, right);
        }

        public static bool operator !=(Pitch left, Pitch right)
        {
            return !(left == right);
        }

        public static Pitch Create(int semitones, bool alterationDirection)
        {
            int octave = (semitones + 9) / 12;

            int ton = (semitones + 9) % 12;
            int alteration = 0;

            while (!Enum.IsDefined(typeof(NoteSemitons), ton))
            {
                if (alterationDirection)
                {
                    alteration++;
                    ton--;
                }
                else
                {
                    alteration--;
                    ton++;
                }
            }

            return Pitch.Create($"{(NoteSemitons)ton}", alteration, octave);
        }

        public Pitch DownOnOctave()
        {
            return new Pitch(this.Note, this._octave - 1);
        }

        public static Pitch Create(string noteStr)
        {
            Note note = Note.Create(noteStr);

            int octave = Convert.ToInt32(noteStr[noteStr.Length - 1].ToString());

            return new Pitch(note, octave);
        }

        public static Pitch Create(string noteStr, int alteration, int octave)
        {
            var note = Note.Create(noteStr, alteration);

            return new Pitch(note, octave);
        }

        public override string ToString()
        {
            return $"{_note}{_octave}";
        }

        public bool EnharmonicEquality(Pitch other)
        {
            return this.GetSemitones() == other.GetSemitones();
        }

        public int CompareTo([AllowNull] Pitch other)
        {
            int hashCode = this.GetSemitones();
            int otherHashCode = other.GetSemitones();
            if (hashCode < otherHashCode)
            {
                return -1;
            }
            if (hashCode > otherHashCode)
            {
                return 1;
            }
            return 0;
        }

        public override int GetHashCode()
        {
            return this.GetSemitones();
        }
    }
}