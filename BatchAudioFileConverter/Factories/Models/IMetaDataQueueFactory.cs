using System.Collections.Generic;
using BatchAudioFileConverter.Models;

namespace BatchAudioFileConverter.Factories.Models
{
    public interface IMetaDataQueueFactory
    {
        IMetaDataQueue Create(IEnumerable<IMetaData> metaData);
    }
}