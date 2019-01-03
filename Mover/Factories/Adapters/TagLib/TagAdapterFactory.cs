using Mover.Adapters.TagLib;
using TagLib;

namespace Mover.Factories.Adapters.TagLib
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
