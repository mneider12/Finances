using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Support
{
    public class MenuOption : IMenuOption
    {
        public string DisplayTitle
        {
            get;
            private set;
        }

        public void select()
        {
            if (menuToOpen != null)
            {
                menuToOpen.run();
            }
            else
            {
                methodToExecute();
            }
        }

        private MenuOption(string displayTitle)
        {
            DisplayTitle = displayTitle;
        }

        public MenuOption(string displayTitle, IMenu menuToOpen) : this(displayTitle)
        {
            this.menuToOpen = menuToOpen;
        }

        public MenuOption(string displayTitle, MethodToExecute methodToExecute) : this(displayTitle)
        {
            this.methodToExecute = methodToExecute;
        }

        private IMenu menuToOpen;
        private MethodToExecute methodToExecute;
    }
}
