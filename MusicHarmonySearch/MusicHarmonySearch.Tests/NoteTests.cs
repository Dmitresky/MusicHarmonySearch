using MusicHarmonySearch.Engine.Catalogs;
using Xunit;

namespace MusicHarmonySearch.Tests
{
    public class NoteTests
    {
        [Fact]
        public void TestCreateNote()
        {
            var actual = Note.Create("Fis");
            Assert.NotNull(actual);
            Assert.Equal(Notes.F, actual.GetTone());
            Assert.Equal(NoteSemitons.F, actual.GetToneSemitons());
            Assert.Equal("Fis", actual.ToString());
        }
    }
}
