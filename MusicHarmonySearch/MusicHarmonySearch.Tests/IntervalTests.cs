using MusicHarmonySearch.Engine;
using MusicHarmonySearch.Engine.Catalogs;
using System;
using Xunit;

namespace MusicHarmonySearch.Tests
{
    public class IntervalTests
    {
        [Theory]
        [InlineData("P1", "A6", "A6")]
        [InlineData("d2", "E6", "Fes6")]
        [InlineData("A1", "A6", "Ais6")]
        [InlineData("m2", "E6", "F6")]
        [InlineData("M2", "A6", "H6")]
        [InlineData("d3", "Ais5", "C6")]
        [InlineData("d3", "Gis5", "B5")]
        [InlineData("A2", "As6", "H6")]
        [InlineData("m3", "A6", "C7")]
        [InlineData("M3", "C6", "E6")]
        [InlineData("d4", "C6", "Fes6")]
        [InlineData("A3", "F6", "Ais6")]
        [InlineData("P4", "C6", "F6")]
        [InlineData("d5", "C6", "Ges6")]
        [InlineData("A4", "C6", "Fis6")]
        [InlineData("P5", "C6", "G6")]
        [InlineData("P5", "G6", "C6")]
        [InlineData("d6", "Cis6", "As6")]
        [InlineData("A5", "C6", "Gis6")]
        [InlineData("m6", "E6", "C7")]
        [InlineData("M6", "C6", "A6")]
        [InlineData("d7", "Cis6", "B6")]
        [InlineData("A6", "C6", "Ais6")]
        [InlineData("m7", "C6", "B6")]
        [InlineData("M7", "C6", "H6")]
        [InlineData("d8", "Cis6", "C7")]
        [InlineData("A7", "F6", "Eis7")]
        [InlineData("P8", "C6", "C7")]
        public void TestIntervalInsideOctave(string expectedInterval, string note1, string note2)
        {
            Assert.Equal(expectedInterval, Interval.Get(Pitch.Create(note1), Pitch.Create(note2)).ToString());
        }

        public void TestCantSpecifyInterval()
        {
            Assert.Throws<ArgumentException>(() => Interval.Get(Pitch.Create("A0"), Pitch.Create("G7")));
        }

        [Theory]
        [InlineData(NumberIntervals.Prime, Notes.A, Notes.A)]
        [InlineData(NumberIntervals.Second, Notes.A, Notes.H)]
        [InlineData(NumberIntervals.Third, Notes.A, Notes.C)]
        [InlineData(NumberIntervals.Sixth, Notes.C, Notes.A)]
        [InlineData(NumberIntervals.Seventh, Notes.H, Notes.A)]
        public void TestNumberIntervals(NumberIntervals expected, Notes lower, Notes higher)
        {
            Assert.Equal(expected, Interval.GetNumberInterval(lower, higher));
        }
    }
}
