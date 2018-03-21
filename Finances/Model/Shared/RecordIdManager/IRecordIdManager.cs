namespace Finances.Model.Shared.RecordIdManager
{
    public interface IRecordIdManager
    {
        int getNextId(RecordType type);
        bool load();
        bool save();
    }
}