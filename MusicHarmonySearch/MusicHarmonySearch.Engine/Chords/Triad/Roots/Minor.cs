using MusicHarmonySearch.Engine.Chords.Inversions;

namespace MusicHarmonySearch.Engine.Chords.Triad.Roots
{
    public class Minor : Chord
    {
        public Minor(Inversion inversion) : base(inversion)
        {
            Postfix = "m";
        }
    }
}