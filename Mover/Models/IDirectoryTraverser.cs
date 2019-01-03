using Mover.Adapters;
using System.Collections.Generic;

namespace Mover.Models
{
    public interface IDirectoryTraverser : IEnumerable<IDirectoryInfo>
    {
        string BasePath { get; }
    }
}