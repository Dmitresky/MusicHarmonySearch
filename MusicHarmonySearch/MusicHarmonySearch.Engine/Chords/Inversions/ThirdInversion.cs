namespace MusicHarmonySearch.Engine.Chords.Inversions
{
    public class ThirdInversion : Inversion
    {
        public ThirdInversion(PitchSet notes) : base(notes)
        {
        }

        public override string GetMainNote()
        {
            return Notes[Notes.Length - 3].GetNote();
        }
    }
}
