using BatchAudioFileConverter.Adapters;
using System.IO;

namespace BatchAudioFileConverter.Factories.Adapters
{
    public interface IDirectoryInfoFactory
    {
        IDirectoryInfo Create(string path);
        IDirectoryInfo Create(DirectoryInfo directoryInfo);
    }
}
