using Mover.Adapters;
using System.IO;

namespace Mover.Factories.Adapters
{
    public interface IDirectoryInfoFactory
    {
        IDirectoryInfo Create(string path);
        IDirectoryInfo Create(DirectoryInfo directoryInfo);
    }
}
