using Finances.Import;
using Finances.Model;
using Finances.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Support
{
    public class MainMenu : IMenu
    {
        public MainMenu(IContext context)
        {
            this.context = context;

            List<IMenuOption> options = new List<IMenuOption>();

            addOption(options, "Import", import);

            menu = new Menu(options);
        }

        public void run()
        {
            menu.run();
        }

        private IMenu menu;
        private IContext context;

        private void addOption(List<IMenuOption> options, string displayTitle, IMenu menuToOpen)
        {
            IMenuOption option = new MenuOption(displayTitle, menuToOpen);
            addOption(options, option);
        }

        private void addOption(List<IMenuOption> options, string displayTitle, MethodToExecute methodToExecute)
        {
            IMenuOption option = new MenuOption(displayTitle, methodToExecute);
            addOption(options, option);
        }

        private void addOption(List<IMenuOption> options, IMenuOption option)
        {
            options.Add(option);
        }

        private void import()
        {
            ICashTransactionFactory cashTransactionFactory = new CashTransactionFactory(context.RecordIdManager);
            ICashTransactionLoader cashTransactionLoader = new CashTransactionLoader(cashTransactionFactory, context.FileSystemManager);


            //cashTransactionLoader.load();
        }
    }
}
