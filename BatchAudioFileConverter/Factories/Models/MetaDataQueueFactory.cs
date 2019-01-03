using BatchAudioFileConverter.Models;
using System.Collections.Generic;

namespace BatchAudioFileConverter.Factories.Models
{
    class MetaDataQueueFactory : IMetaDataQueueFactory
    {
        public IMetaDataQueue Create(IEnumerable<IMetaData> metaData)
        {
            return new MetaDataQueue(metaData);
        }
    }
}
