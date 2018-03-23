namespace Finances.Model
{
    public interface IRecordIdManager
    {
        int getNextId(RecordType type);
    }
}