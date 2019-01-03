using BatchAudioFileConverter.Models;

namespace BatchAudioFileConverter.Services
{
    public interface IDirectoryService
    {
        IDirectoryStructureReplicator PrepareReplication(string inputPath, string outputPath);
        IDirectoryTraverser Traverse(string path);
    }
}