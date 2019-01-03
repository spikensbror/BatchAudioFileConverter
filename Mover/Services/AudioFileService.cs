using Mover.Models;

namespace Mover.Services
{
    class AudioFileService : IAudioFileService
    {
        public IAudioFileConverter PrepareConversion(IMetaData metaData)
        {
            return new AudioFileConverter(metaData);
        }
    }
}
