using Mover.Models;

namespace Mover.Services
{
    interface IAudioFileService
    {
        IAudioFileConverter PrepareConversion(IMetaData metaData);
    }
}