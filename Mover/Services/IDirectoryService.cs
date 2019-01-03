using Mover.Models;

namespace Mover.Services
{
    public interface IDirectoryService
    {
        IDirectoryStructureReplicator PrepareReplication(string inputPath, string outputPath);
        IDirectoryTraverser Traverse(string path);
    }
}