using System.IO;

namespace BatchAudioFileConverter.Adapters
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
