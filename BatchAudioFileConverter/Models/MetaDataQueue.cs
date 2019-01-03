using System.Collections.Generic;

namespace BatchAudioFileConverter.Models
{
    class MetaDataQueue : IMetaDataQueue
    {
        public Queue<IMetaData> Containers { get; }

        public MetaDataQueue(IEnumerable<IMetaData> metaData)
        {
            this.Containers = new Queue<IMetaData>(metaData);
        }

        public bool IsEmpty()
        {
            lock (this)
            {
                return this.Containers.Count == 0;
            }
        }

        public IMetaData Dequeue()
        {
            lock (this)
            {
                return this.Containers.Dequeue();
            }
        }
    }
}
