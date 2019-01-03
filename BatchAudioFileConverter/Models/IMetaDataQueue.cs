namespace BatchAudioFileConverter.Models
{
    public interface IMetaDataQueue
    {
        IMetaData Dequeue();
        bool IsEmpty();
    }
}