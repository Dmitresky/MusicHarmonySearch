using MusicHarmonySearch.Engine;
using System.Linq;
using Xunit;

namespace MusicHarmonySearch.Tests
{
    public class EngineOneChordTests
    {
        private readonly MusicXmlDeserializer _deserializer;

        public EngineOneChordTests()
        {
            _deserializer = new MusicXmlDeserializer();
        }

        [Fact]
        public void TestValidDeserializtion()
        {
            var result = _deserializer.Run("MusicXmlfiles/Am.xml");
            Assert.NotNull(result);
        }

        [Fact]
        public void TestGettingNotes()
        {
            var result = _deserializer.Run("MusicXmlfiles/Am.xml");
            Assert.Equal(new[] { "A2", "C4", "E4", "A4" }, result.GetChords()[0].GetNotes().Select(x => x.ToString()));
            Assert.Equal(new[] { Pitch.Create("A2"), Pitch.Create("C4"), Pitch.Create("E4"), Pitch.Create("A4") }, result.GetChords()[0].GetNotes());
        }

        [Fact]
        public void TestGettingNotesWithFlat()
        {
            var result = _deserializer.Run("MusicXmlFiles/Gm_B7.xml");
            Assert.Equal(new[] { "B2", "D4", "F4", "As4" }, result.GetChords()[0].GetNotes().Select(x => x.ToString()));
        }
        
        [Fact]
        public void TestGettingNotesWithSharp()
        {
            var result = _deserializer.Run("MusicXmlFiles/Fis-dur_D7.xml");
            Assert.Equal(new[] { "Cis3", "Eis4", "Gis4", "H4" }, result.GetChords()[0].GetNotes().Select(x => x.ToString()));
        }

        [Fact]
        public void TestGettingNotesWithHsharp()
        {
            var result = _deserializer.Run("MusicXmlFiles/Cis-dur_D7.xml");
            Assert.Equal(new[] { "Gis3", "His3", "Dis4", "Fis4" }, result.GetChords()[0].GetNotes().Select(x => x.ToString()));
        }

        [Fact]
        public void TestGettingNotesWithH()
        {
            var result = _deserializer.Run("MusicXmlFiles/G-dur_G.xml");
            Assert.Equal(new[] { "G3", "H3", "D4" }, result.GetChords()[0].GetNotes().Select(x => x.ToString()));
        }
    }
}
