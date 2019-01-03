using Mover.Adapters.TagLib;
using System;

namespace Mover.Models
{
    public interface IMetaData
    {
        string InputFilePath { get; }
        Lazy<string> OutputFilePath { get; }
        ITag Tag { get; }
    }
}