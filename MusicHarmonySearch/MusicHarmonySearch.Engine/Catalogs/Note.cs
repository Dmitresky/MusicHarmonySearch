using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MusicHarmonySearch.Engine.Catalogs
{
    public class Note : IEquatable<Note>
    {
        private readonly Notes _note;
        private readonly NoteSemitons _noteSemitons;
        private readonly int _alteration;

        private Note(Notes notes, NoteSemitons noteSemitons, int alterartion)
        {
            this._note = notes;
            this._noteSemitons = noteSemitons;
            this._alteration = alterartion;
        }

        public static Note Create(string noteStr)
        {
            string tone = noteStr[0].ToString();

            int alteration = 0;
            if (noteStr.Contains("is"))
            {
                alteration++;
            }
            else
            {
                if (tone == "A" || tone == "E")
                {
                    if (noteStr.Contains("s"))
                    {
                        alteration--;
                    }
                }
            }

            if (noteStr.Contains("es"))
            {
                alteration--;
            }

            if (tone == "B")
            {
                tone = "H";
                alteration--;
            }

            return Note.Create(tone, alteration);
        }

        public static Note Create(string tone, int alteration)
        {

            if (!Enum.TryParse(tone, out Notes note))
            {
                throw new ArgumentException(nameof(tone));
            };

            if (!Enum.TryParse(tone, out NoteSemitons noteSemitiones))
            {
                throw new ArgumentException(nameof(tone));
            };

            return new Note(note, noteSemitiones, alteration);
        }

        public bool Equals([AllowNull] Note other)
        {
            if (other == null)
            {
                return false;
            }

            return this._note == other._note
                && this._alteration == other._alteration
                && this._noteSemitons == other._noteSemitons;
        }

        public Notes GetTone()
        {
            return _note;
        }

        public NoteSemitons GetToneSemitons()
        {
            return _noteSemitons;
        }

        public NoteSemitons GetNoteSemitons()
        {
            return _noteSemitons + _alteration;
        }

        public static bool operator ==(Note left, Note right)
        {
            return EqualityComparer<Note>.Default.Equals(left, right);
        }

        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            if (_alteration != 0)
            {
                if (_alteration == -1)
                {
                    if (_note == Notes.A || _note == Notes.E)
                    {
                        return $"{_note}s";
                    }

                    if (_note == Notes.H)
                    {
                        return $"B";
                    }

                    return $"{_note}es";
                }

                if (_alteration == 1)
                {
                    return $"{_note}is";
                }
            }
            return $"{_note}";
        }
    }
}