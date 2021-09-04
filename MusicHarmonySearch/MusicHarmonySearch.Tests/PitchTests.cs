using MusicHarmonySearch.Engine;
using MusicHarmonySearch.Engine.Catalogs;
using MusicHarmonySearch.Engine.Chords;
using Xunit;

namespace MusicHarmonySearch.Tests
{
    public class PitchTests
    {
        [Fact]
        public void TestComparisonOfPitches()
        {
            Assert.True(Pitch.Create("A4") == Pitch.Create("A4"));
            Assert.True(Pitch.Create("A4") != Pitch.Create("A5"));
        }

        [Theory]
        [InlineData("A4", "A4")]
        [InlineData("Ais5", "Ais5")]
        public void TestPitchToString(string expected, string note)
        {
            Assert.Equal(expected, Pitch.Create(note).ToString());
        }

        [Fact]
        public void TestPitchToEnumAndOtherwise()
        {
            Assert.Equal("A", Notes.A.ToString());
        }

        [Fact]
        public void TestAPitchLowerThanOther()
        {
            Assert.True(Pitch.Create("Fis3").GetSemitones() < Pitch.Create("Gis3").GetSemitones());
            Assert.True(Pitch.Create("C5").GetSemitones() < Pitch.Create("A5").GetSemitones());
        }

        [Theory]
        [InlineData(0, "A0")]
        [InlineData(1, "B0")]
        [InlineData(2, "H0")]
        [InlineData(3, "C1")]
        [InlineData(33, "Fis3")]
        [InlineData(33, "Ges3")]
        public void TestGetSemitones(int expectedId, string note)
        {
            Assert.Equal(expectedId, Pitch.Create(note).GetSemitones());
        }

        [Fact]
        public void TestEnharmonicEquality()
        {
            var note1 = Pitch.Create("Fis3");
            var note2 = Pitch.Create("Ges3");
            Assert.False(note1 == note2);
            Assert.True(note1.EnharmonicEquality(note2));
        }

        [Fact]
        public void TestPitchDownOnOctave()
        {
            var expected = Pitch.Create("A4");
            var actual = Pitch.Create("A5").DownOnOctave();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNoteSetPack()
        {
            var notes = PitchSet.Create("A2", "C5", "E7", "A7");
            Assert.Equal(new[] { Pitch.Create("A2"), Pitch.Create("C3"), Pitch.Create("E3") }, notes.Packed);
        }
    }
}
