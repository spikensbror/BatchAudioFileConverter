using Mover.Adapters.TagLib;

namespace Mover.Factories.Adapters.TagLib
{
    public interface ITagFactory
    {
        ITag Create(string filePath);
    }
}