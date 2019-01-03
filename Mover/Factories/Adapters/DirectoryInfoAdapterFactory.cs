using Mover.Adapters;
using System.IO;

namespace Mover.Factories.Adapters
{
    class DirectoryInfoAdapterFactory : IDirectoryInfoFactory
    {
        private readonly IFileInfoFactory fileInfoFactory;

        public DirectoryInfoAdapterFactory(IFileInfoFactory fileInfoFactory)
        {
            this.fileInfoFactory = fileInfoFactory;
        }

        public IDirectoryInfo Create(string path)
        {
            return this.Create(new DirectoryInfo(path));
        }

        public IDirectoryInfo Create(DirectoryInfo directoryInfo)
        {
            return new DirectoryInfoAdapter(this, this.fileInfoFactory, directoryInfo);
        }
    }
}
