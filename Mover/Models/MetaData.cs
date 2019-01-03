using Mover.Adapters.TagLib;
using System;

namespace Mover.Models
{
    class MetaData : IMetaData
    {
        public IPathTransformer PathTransformer { get; }

        public string InputBasePath { get; }
        public string OutputBasePath { get; }

        public ITag Tag { get; }
        public string InputFilePath { get; }
        public Lazy<string> OutputFilePath { get; }

        public MetaData(IPathTransformer pathTransformer
            , ITag tag
            , string inputBasePath
            , string inputFilePath
            , string outputBasePath
            )
        {
            this.PathTransformer = pathTransformer;

            this.Tag = tag;
            this.InputBasePath = inputBasePath;
            this.InputFilePath = inputFilePath;
            this.OutputBasePath = outputBasePath;

            this.OutputFilePath = new Lazy<string>(this.CreateOutputFilePath);
        }

        private string CreateOutputFilePath()
        {
            return this.PathTransformer.Transform(this.InputBasePath
                , this.InputFilePath
                , this.OutputBasePath
                )
                .ToString()
                .Replace(".m4a", ".mp3");
        }
    }
}
