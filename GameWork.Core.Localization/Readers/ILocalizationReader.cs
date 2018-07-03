using System.IO;

namespace GameWork.Core.Localization.Readers
{
    public interface ILocalizationReader
    {
        LocalizationModel Read(Stream stream);
    }
}
