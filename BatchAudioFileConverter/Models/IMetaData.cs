using BatchAudioFileConverter.Adapters.TagLib;
using System;

namespace BatchAudioFileConverter.Models
{
    public interface IMetaData
    {
        string InputFilePath { get; }
        Lazy<string> OutputFilePath { get; }
        ITag Tag { get; }
    }
}