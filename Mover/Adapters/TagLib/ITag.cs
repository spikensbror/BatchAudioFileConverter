using TagLib;

namespace Mover.Adapters.TagLib
{
    public interface ITag
    {
        string Album { get; }
        string Artist { get; }
        string Comment { get; }
        string Genre { get; }
        string Title { get; }
        string Track { get; }
        string Year { get; }
        string Disc { get; }

        void CopyTo(string targetFilePath);
    }
}