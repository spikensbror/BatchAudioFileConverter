using BatchAudioFileConverter.Models;

namespace BatchAudioFileConverter.Services
{
    class AudioFileService : IAudioFileService
    {
        public IAudioFileConverter PrepareConversion(IMetaData metaData)
        {
            return new AudioFileConverter(metaData);
        }
    }
}
