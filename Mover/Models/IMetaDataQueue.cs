namespace Mover.Models
{
    public interface IMetaDataQueue
    {
        IMetaData Dequeue();
        bool IsEmpty();
    }
}