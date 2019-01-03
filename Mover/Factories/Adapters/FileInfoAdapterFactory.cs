using Mover.Adapters;
using System.IO;

namespace Mover.Factories.Adapters
{
    class FileInfoAdapterFactory : IFileInfoFactory
    {
        public IFileInfo Create(string path)
        {
            return this.Create(new FileInfo(path));
        }

        public IFileInfo Create(FileInfo fileInfo)
        {
            return new FileInfoAdapter(fileInfo);
        }
    }
}
