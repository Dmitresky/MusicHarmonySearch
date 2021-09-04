using MusicHarmonySearch.Engine.Chords.Inversions;

namespace MusicHarmonySearch.Engine.Chords.Triad.Roots
{
    public class Augmented : Chord
    {
        public Augmented(Inversion inversion) : base(inversion)
        {
            Postfix = "aug";
        }
    }
}