using BatchAudioFileConverter.Models;

namespace BatchAudioFileConverter.Services
{
    interface IAudioFileService
    {
        IAudioFileConverter PrepareConversion(IMetaData metaData);
    }
}