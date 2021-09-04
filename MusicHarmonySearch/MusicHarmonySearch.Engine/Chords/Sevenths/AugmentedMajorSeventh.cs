using MusicHarmonySearch.Engine.Chords.Triad.Roots;

namespace MusicHarmonySearch.Engine.Chords.Sevenths
{
    public class AugmentedMajorSeventh : Augmented
    {
        public AugmentedMajorSeventh(Inversions.Inversion inversion) : base(inversion)
        {
            Postfix = $"{Postfix}7";
        }
    }
}
