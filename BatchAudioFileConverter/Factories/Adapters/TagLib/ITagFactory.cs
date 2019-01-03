using BatchAudioFileConverter.Adapters.TagLib;

namespace BatchAudioFileConverter.Factories.Adapters.TagLib
{
    public interface ITagFactory
    {
        ITag Create(string filePath);
    }
}