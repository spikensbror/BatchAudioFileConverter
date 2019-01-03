using System.Collections.Generic;

namespace Mover.Adapters
{
    public interface IDirectoryInfo
    {
        string FullName { get; }

        IEnumerable<IDirectoryInfo> EnumerateDirectories();
        IFileInfo[] GetFiles(string searchPattern);
    }
}
