using MusicHarmonySearch.Engine.Chords.Inversions;
using MusicHarmonySearch.Engine.Chords.Triad.Roots;

namespace MusicHarmonySearch.Engine.Chords.Sevenths
{
    public class DominantSeventh : Major
    {
        public DominantSeventh(Inversion inversion) : base(inversion)
        {
            Postfix = "7";
        }
    }
}
