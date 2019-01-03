using BatchAudioFileConverter.Adapters;
using System.Collections.Generic;

namespace BatchAudioFileConverter.Models
{
    public interface IDirectoryTraverser : IEnumerable<IDirectoryInfo>
    {
        string BasePath { get; }
    }
}