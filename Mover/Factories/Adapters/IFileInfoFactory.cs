using Mover.Adapters;
using System.IO;

namespace Mover.Factories.Adapters
{
    public interface IFileInfoFactory
    {
        IFileInfo Create(string path);
        IFileInfo Create(FileInfo fileInfo);
    }
}
