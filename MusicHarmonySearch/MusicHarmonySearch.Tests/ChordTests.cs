using MusicHarmonySearch.Engine.Chords;
using System;
using System.Linq;
using Xunit;

namespace MusicHarmonySearch.Tests
{
    public class ChordTests
    {
        [Fact]
        public void TestGettingNotes()
        {
            var chord = Chord.Create("A4", "E5", "C5");

            Assert.Equal(new[] { "A4", "C5", "E5" }, chord.GetNotes().Select(x => x.ToString()));
        }

        [Fact]
        public void TestChordCtorException()
        {
            Assert.Throws<ArgumentException>(() => Chord.Create("A0"));
            Assert.Throws<ArgumentException>(() => Chord.Create("A0", "B0"));
        }

        [Fact]
        public void TestEqualityChords()
        {
            var chord1 = Chord.Create("A4", "C5", "E5");
            var chord2 = Chord.Create("A4", "C5", "E5");
            Assert.True(chord1 == chord2);
        }

        [Fact]
        public void TestNonEqualityChords()
        {
            var chord1 = Chord.Create("A4", "C5", "E5");
            var chord2 = Chord.Create("A3", "C5", "E5");
            Assert.True(chord1 != chord2);
        }

        [Theory]
        [InlineData("C", "C6", "E6", "G6")]
        [InlineData("C/E", "E6", "G6", "C7")]
        [InlineData("C/G", "G6", "C7", "E7")]
        [InlineData("Am", "A5", "C6", "E6")]
        [InlineData("Am/C", "C6", "E6", "A6")]
        [InlineData("Am/E", "E6", "A6", "C7")]
        [InlineData("Daug/Fis", "Fis5", "Ais5", "D6")]
        [InlineData("Daug/Ais", "Ais5", "D6", "Fis6")]
        [InlineData("Daug", "D5", "Fis5", "Ais5")]
        [InlineData("Edim", "E5", "G5", "B5")]
        [InlineData("Edim/G", "G5", "B5", "E6")]
        [InlineData("Edim/B", "B5", "E6", "G6")]
        public void TestChordName3Notes(string chordName, string note1, string note2, string note3)
        {
            Assert.Equal(chordName, Chord.Create(note1, note2, note3).GetName());
        }

        [Theory]
        [InlineData("C7", "C6", "E6", "G6", "B6")]
        [InlineData("C7/E", "E6", "G6", "B6", "C7")]
        [InlineData("C7/G", "G6", "B6", "C7", "E7")]
        [InlineData("C7/B", "B6", "C7", "E7", "G7")]
        [InlineData("Am7", "A5", "C6", "E6", "G6")]
        [InlineData("Am7/C", "C6", "E6", "G6", "A6")]
        [InlineData("Am7/E", "E6", "G6", "A6", "C7")]
        [InlineData("Am7/G", "G6", "A6", "C7", "E7")]
        [InlineData("Daug7", "D5", "Fis5", "Ais5", "Cis6")]
        [InlineData("Daug7/Fis", "Fis5", "Ais5", "Cis6", "D6")]
        [InlineData("Daug7/Ais", "Ais5", "Cis6", "D6", "Fis6")]
        [InlineData("Daug7/Cis", "Cis6", "D6", "Fis6", "Ais6")]
        [InlineData("Edim7", "E5", "G5", "B5", "Des6")]
        [InlineData("Edim7/G", "G5", "B5", "Des6", "E6")]
        [InlineData("Edim7/B", "B5", "Des6", "E6", "G6")]
        [InlineData("Edim7/Des", "Des6", "E6", "G6", "B6")]
        public void TestChordName4Notes(string chordName, string note1, string note2, string note3, string note4)
        {
            Assert.Equal(chordName, Chord.Create(note1, note2, note3, note4).GetName());
        }

        [Fact]
        public void TestGetMainTonOfChord()
        {
            Assert.Equal("F", Chord.Create("F5", "A5", "C6").GetMainNote());
            Assert.Equal("F", Chord.Create("A5", "F6", "C6").GetMainNote());
            Assert.Equal("C", Chord.Create("C5", "E5", "G5").GetMainNote());
            Assert.Equal("C", Chord.Create("E5", "C6", "G5").GetMainNote());
        }

        [Fact]
        public void TestGetBassNote()
        {
            var chord = Chord.Create("A5", "F6", "C6");
            Assert.Equal("A", chord.GetBase().ToString());
        }
    }
}
