using System.Collections.Generic;
using Mover.Models;

namespace Mover.Factories.Models
{
    public interface IMetaDataQueueFactory
    {
        IMetaDataQueue Create(IEnumerable<IMetaData> metaData);
    }
}