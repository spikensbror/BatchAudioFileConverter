using BatchAudioFileConverter.Adapters.TagLib;
using TagLib;

namespace BatchAudioFileConverter.Factories.Adapters.TagLib
{
    class TagAdapterFactory : ITagFactory
    {
        public ITag Create(string filePath)
        {
            using (var file = File.Create(filePath))
            {
                return new TagAdapter(file.Tag);
            }
        }
    }
}
