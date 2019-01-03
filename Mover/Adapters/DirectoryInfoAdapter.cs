using Mover.Factories.Adapters;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mover.Adapters
{
    class DirectoryInfoAdapter : IDirectoryInfo
    {
        public IDirectoryInfoFactory DirectoryInfoFactory { get; }
        public IFileInfoFactory FileInfoFactory { get; }
        public DirectoryInfo DirectoryInfo { get; }

        public string FullName => this.DirectoryInfo.FullName;

        public DirectoryInfoAdapter(IDirectoryInfoFactory directoryInfoFactory
            , IFileInfoFactory fileInfoFactory
            , DirectoryInfo directoryInfo)
        {
            this.DirectoryInfoFactory = directoryInfoFactory;
            this.FileInfoFactory = fileInfoFactory;
            this.DirectoryInfo = directoryInfo;
        }
        
        public IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            return this.DirectoryInfo
                .EnumerateDirectories()
                .Select(di => this.DirectoryInfoFactory.Create(di));
        }

        public IFileInfo[] GetFiles(string searchPattern)
        {
            return this.DirectoryInfo
                .GetFiles(searchPattern)
                .Select(fi => this.FileInfoFactory.Create(fi))
                .ToArray();
        }
    }
}
