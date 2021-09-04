namespace MusicHarmonySearch.Engine.Chords.Inversions
{
    public class NoInversion : Inversion
    {
        public NoInversion(PitchSet notes) : base(notes)
        {
        }

        public override string GetMainNote()
        {
            return Notes[0].GetNote();
        }
    }
}
