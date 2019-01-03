using System.IO;

namespace Mover.Adapters
{
    class FileInfoAdapter : IFileInfo
    {
        public FileInfo FileInfo { get; }

        public string FullName => this.FileInfo.FullName;

        public FileInfoAdapter(FileInfo fileInfo)
        {
            this.FileInfo = fileInfo;
        }
    }
}
