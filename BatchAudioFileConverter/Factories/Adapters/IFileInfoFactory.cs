using BatchAudioFileConverter.Adapters;
using System.IO;

namespace BatchAudioFileConverter.Factories.Adapters
{
    public interface IFileInfoFactory
    {
        IFileInfo Create(string path);
        IFileInfo Create(FileInfo fileInfo);
    }
}
