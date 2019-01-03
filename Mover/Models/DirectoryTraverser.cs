using Mover.Adapters;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mover.Models
{
    public class DirectoryTraverser : IEnumerable<IDirectoryInfo>, IDirectoryTraverser
    {
        public string BasePath { get; }
        List<IDirectoryInfo> Info { get; }

        public DirectoryTraverser(string path, IDirectoryInfo directoryInfo)
        {
            this.BasePath = path;
            this.Info = this.ExtractDirectoryInfo(directoryInfo).ToList();
        }

        public IEnumerator<IDirectoryInfo> GetEnumerator()
        {
            return this.Info.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Info.GetEnumerator();
        }

        IDirectoryInfo[] ExtractDirectoryInfo(IDirectoryInfo currentDirectory)
        {
            return currentDirectory.EnumerateDirectories()
                .SelectMany(cd => cd.EnumerateDirectories())
                .ToArray();

            var directoryInfo = new List<IDirectoryInfo>();

            foreach (var directory in currentDirectory.EnumerateDirectories())
            {
                directoryInfo.Add(directory);
                directoryInfo.AddRange(this.ExtractDirectoryInfo(directory));
            }

            return directoryInfo.ToArray();
        }
    }
}
