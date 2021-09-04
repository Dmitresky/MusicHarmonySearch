using MusicHarmonySearch.Engine.Chords.Inversions;

namespace MusicHarmonySearch.Engine.Chords.Triad.Roots
{
    public class Diminished : Chord
    {
        public Diminished(Inversion inversion) : base(inversion)
        {
            Postfix = "dim";
        }
    }
}