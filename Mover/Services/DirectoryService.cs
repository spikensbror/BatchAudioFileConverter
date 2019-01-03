using Mover.Factories.Adapters;
using Mover.Models;

namespace Mover.Services
{
    class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryInfoFactory directoryInfoFactory;
        private readonly IPathTransformer pathTransformer;

        public IDirectoryService Self { get; set; }

        public DirectoryService(IDirectoryInfoFactory directoryInfoFactory
            , IPathTransformer pathTransformer
            )
        {
            this.directoryInfoFactory = directoryInfoFactory;
            this.pathTransformer = pathTransformer;

            this.Self = this;
        }

        public IDirectoryStructureReplicator PrepareReplication(string inputPath, string outputPath)
        {
            return new DirectoryStructureReplicator(this.pathTransformer
                , this.Self.Traverse(inputPath)
                , outputPath
                );
        }

        public IDirectoryTraverser Traverse(string path)
        {
            return new DirectoryTraverser(path, this.directoryInfoFactory.Create(path));
        }
    }
}
