using System.Collections.Generic;

namespace BatchAudioFileConverter.Adapters
{
    public interface IDirectoryInfo
    {
        string FullName { get; }

        IEnumerable<IDirectoryInfo> EnumerateDirectories();
        IFileInfo[] GetFiles(string searchPattern);
    }
}
