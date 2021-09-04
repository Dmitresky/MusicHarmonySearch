using System.Xml;
using System.Xml.Serialization;

namespace MusicHarmonySearch.Engine
{
    public class MusicXmlDeserializer
    {
        public MusicXmlDeserializer()
        {
        }

        public Score Run(string pathfile)
        {
            XmlSerializer ser = new XmlSerializer(typeof(scorepartwise));
            scorepartwise scorepartwise;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse; 
            settings.MaxCharactersFromEntities = 1024; // avoid DoS attacks which can be happen because of DtdProcessing.Parse

            using (XmlReader reader = XmlReader.Create(pathfile, settings))
            {
                scorepartwise = (scorepartwise)ser.Deserialize(reader);
            }
            return new Score(scorepartwise);
        }
    }
}