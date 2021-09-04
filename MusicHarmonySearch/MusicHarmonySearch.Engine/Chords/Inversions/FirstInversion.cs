namespace MusicHarmonySearch.Engine.Chords.Inversions
{
    public class FirstInversion : Inversion
    {
        public FirstInversion(PitchSet notes) : base(notes)
        {
        }

        public override string GetMainNote()
        {
            return Notes[Notes.Length-1].GetNote();
        }
    }
}
