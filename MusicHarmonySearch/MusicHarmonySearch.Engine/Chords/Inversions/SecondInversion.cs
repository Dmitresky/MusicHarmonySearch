namespace MusicHarmonySearch.Engine.Chords.Inversions
{
    public class SecondInversion : Inversion
    {
        public SecondInversion(PitchSet notes) : base(notes)
        {
        }

        public override string GetMainNote()
        {
            return Notes[Notes.Length - 2].GetNote();
        }
    }
}
