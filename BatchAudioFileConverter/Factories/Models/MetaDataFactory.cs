using BatchAudioFileConverter.Factories.Adapters.TagLib;
using BatchAudioFileConverter.Models;

namespace BatchAudioFileConverter.Factories.Models
{
    class MetaDataFactory : IMetaDataFactory
    {
        private readonly IPathTransformer pathTransformer;
        private readonly ITagFactory tagFactory;

        public MetaDataFactory(IPathTransformer pathTransformer
            , ITagFactory tagFactory
            )
        {
            this.pathTransformer = pathTransformer;
            this.tagFactory = tagFactory;
        }

        public IMetaData Create(string inputBasePath
            , string inputFilePath
            , string outputBasePath
            )
        {
            return new MetaData(this.pathTransformer
                , this.tagFactory.Create(inputFilePath)
                , inputBasePath
                , inputFilePath
                , outputBasePath
                );
        }
    }
}
