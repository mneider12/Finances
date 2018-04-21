using Finances.IO;

namespace FinancesInstall.Support
{
    internal interface IDatabaseInstaller
    {
        void run(IDatabaseManager databaseManager);
    }
}
