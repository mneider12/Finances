using Admin.Support;
using Finances.Import;
using Finances.IO;
using Finances.Model;
using Finances.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Main
{
    /// <summary>
    /// class to house the admin console main method
    /// </summary>
    public static class Admin
    {
        /// <summary>
        /// run the administrator console
        /// </summary>
        public static void Main()
        {
            string rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            IContext context = new Context(rootDirectory);

            IMenu mainMenu = new MainMenu(context);
            mainMenu.run();
        }
    }
    
}
