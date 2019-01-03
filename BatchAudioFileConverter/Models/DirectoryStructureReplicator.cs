using System.IO;

namespace BatchAudioFileConverter.Models
{
    class DirectoryStructureReplicator : IDirectoryStructureReplicator
    {
        public IPathTransformer PathTransformer { get; }
        public IDirectoryTraverser InputDirectoryTraverser { get; }
        public string OutputPath { get; }

        public DirectoryStructureReplicator(IPathTransformer pathTransformer
            , IDirectoryTraverser inputDirectoryTraverser
            , string outputPath
            )
        {
            this.PathTransformer = pathTransformer;
            this.InputDirectoryTraverser = inputDirectoryTraverser;
            this.OutputPath = outputPath;
        }

        public void Replicate()
        {
            foreach (var inputDirectory in this.InputDirectoryTraverser)
            {
                var outputDirectoryPath = this.PathTransformer.Transform(this.InputDirectoryTraverser.BasePath
                    , inputDirectory.FullName
                    , this.OutputPath
                    ).ToString();

                // TODO: DirectoryAdapter
                if (!Directory.Exists(outputDirectoryPath))
                {
                    Directory.CreateDirectory(outputDirectoryPath);
                }
            }
        }
    }
}
