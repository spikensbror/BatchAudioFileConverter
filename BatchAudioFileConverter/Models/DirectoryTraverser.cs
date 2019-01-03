using BatchAudioFileConverter.Adapters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BatchAudioFileConverter.Models
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
        }
    }
}
