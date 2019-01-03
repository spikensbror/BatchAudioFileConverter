using Mover.Models;
using System.Collections.Generic;

namespace Mover.Factories.Models
{
    class MetaDataQueueFactory : IMetaDataQueueFactory
    {
        public IMetaDataQueue Create(IEnumerable<IMetaData> metaData)
        {
            return new MetaDataQueue(metaData);
        }
    }
}
