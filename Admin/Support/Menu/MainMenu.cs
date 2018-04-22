using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Support
{
    public class MainMenu : IMenu
    {
        public MainMenu()
        {
            List<IMenuOption> options = new List<IMenuOption>();

            addOption(options, "Import", import);

            menu = new Menu(options);
        }

        public void run()
        {
            menu.run();
        }

        IMenu menu;

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
            Console.WriteLine("importing");
        }
    }
}
