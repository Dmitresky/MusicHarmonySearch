using MusicHarmonySearch.Engine.Chords;
using System;
using System.Collections.Generic;

namespace MusicHarmonySearch.Engine
{
    public class Score
    {
        private scorepartwise scorepartwise;

        public Score(scorepartwise scorepartwise)
        {
            this.scorepartwise = scorepartwise;
        }

        private Pitch[] GetNotes()
        {
            List<Pitch> notes = new List<Pitch>();

            foreach (var item in this.scorepartwise.part[0].measure[0].Items)
            {
                var note = item as note;
                if (note != null)
                {
                    foreach (var noteItem in note.Items)
                    {
                        var pitch = noteItem as pitch;
                        if (pitch != null)
                        {
                            notes.Add(GetNote(pitch));
                        }
                    }
                }
            }

            return notes.ToArray();
        }

        public Chord[] GetChords()
        {
            List<Chord> chords = new List<Chord>();
            var notes = GetNotes();

            var chord = Chord.Create(notes);

            chords.Add(chord);

            return chords.ToArray();
        }

        private Pitch GetNote(pitch pitch)
        {
            string step = pitch.step == global::step.B ? "H" : pitch.step.ToString();
            return Pitch.Create($"{step}", (int)pitch.alter, Convert.ToInt32(pitch.octave));
        }
    }
}
