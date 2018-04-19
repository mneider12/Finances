using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Model;
using Finances.IO;
using System.IO;

namespace Finances.Import
{
    public class CashTransactionLoader : ICashTransactionLoader
    {
        public CashTransactionLoader(ICashTransactionFactory cashTransactionFactory, IFileSystemManager fileSystemManager)
        {
            this.cashTransactionFactory = cashTransactionFactory;
            this.fileSystemManager = fileSystemManager;
        }

        public List<ICashTransaction> load(string relativeFilePath)
        {
            List<ICashTransaction> cashTransactions = new List<ICashTransaction>();

            using (FileStream fileStream = File.Create(relativeFilePath))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string cashTransactionData = reader.ReadLine();
                    ICashTransaction cashTransaction = createOneCashTransaction(cashTransactionData, cashTransactionFactory);
                }                    
            }
                return cashTransactions;
        }

        private ICashTransaction createOneCashTransaction(string cashTransactionData, ICashTransactionFactory cashTransactionFactory)
        {
            string[] cashTransactionDataPieces = cashTransactionData.Split(',');

            string[] datePieces = cashTransactionDataPieces[0].Split('/');
            int day, month, year;
            day = int.Parse(datePieces[0]);
            month = int.Parse(datePieces[1]);
            year = int.Parse(datePieces[2]);
            DateTime date = new DateTime(year, month, day);

            decimal amount = decimal.Parse(cashTransactionDataPieces[1]);

            return cashTransactionFactory.create(date, amount);
        }

        private ICashTransactionFactory cashTransactionFactory;
        private IFileSystemManager fileSystemManager;
    }
}
