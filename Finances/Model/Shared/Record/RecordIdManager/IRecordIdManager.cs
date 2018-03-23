namespace Finances.Model.Shared
{
    public interface IRecordIdManager
    {
        int getNextId(RecordType type);
    }
}