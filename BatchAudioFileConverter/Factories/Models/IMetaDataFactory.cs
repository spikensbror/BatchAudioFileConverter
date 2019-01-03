using BatchAudioFileConverter.Models;

namespace BatchAudioFileConverter.Factories.Models
{
    public interface IMetaDataFactory
    {
        IMetaData Create(string inputBasePath
            , string inputFilePath
            , string outputBasePath
            );
    }
}