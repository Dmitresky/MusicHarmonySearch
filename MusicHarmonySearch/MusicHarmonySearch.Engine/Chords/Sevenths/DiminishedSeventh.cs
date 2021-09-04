using MusicHarmonySearch.Engine.Chords.Inversions;
using MusicHarmonySearch.Engine.Chords.Triad.Roots;

namespace MusicHarmonySearch.Engine.Chords.Sevenths
{
    public class DiminishedSeventh : Diminished
    {
        public DiminishedSeventh(Inversion inversion) : base(inversion)
        {
            Postfix = $"{Postfix}7";
        }
    }
}
