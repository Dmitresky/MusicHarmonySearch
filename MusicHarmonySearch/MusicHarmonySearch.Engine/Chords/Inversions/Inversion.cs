using System;
using System.Collections.Generic;

namespace MusicHarmonySearch.Engine.Chords.Inversions
{
    public abstract class Inversion
    {
        protected PitchSet Notes;

        public Inversion(PitchSet notes)
        {
            Notes = notes;
        }

        public abstract string GetMainNote();

        public string GetBase()
        {
            return Notes[0].GetNote();
        }

        public string GetName(string postfix = "")
        {
            string mainNote = this.GetMainNote();
            string baseNote = this.GetBase();
            string name = $"{mainNote}{postfix}";

            if (!string.Equals(mainNote, baseNote))
            {
                return $"{name}/{baseNote}";
            }

            return name;
        }

        public IEnumerable<Pitch> GetNotes()
        {
            foreach (var note in Notes)
            {
                yield return note;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Inversion inversion &&
                   EqualityComparer<PitchSet>.Default.Equals(Notes, inversion.Notes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Notes);
        }

        public static bool operator ==(Inversion left, Inversion right)
        {
            return EqualityComparer<Inversion>.Default.Equals(left, right);
        }

        public static bool operator !=(Inversion left, Inversion right)
        {
            return !(left == right);
        }
    }
}
