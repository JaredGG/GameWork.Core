using System.IO;
using GameWork.Core.IO.Readers.PlatformAdaptors;

namespace GameWork.Core.Localization.Readers
{
    public class JsonReader : ILocalizationReader
    {
        private readonly IJsonReader _jsonReader;

        public JsonReader(IJsonReader jsonReader)
        {
            _jsonReader = jsonReader;
        }

        public LocalizationModel Read(Stream stream)
        {
            return _jsonReader.ConstructModel<LocalizationModel>(stream);
        }
    }
}
