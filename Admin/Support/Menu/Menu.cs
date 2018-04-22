using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Support
{
    public class Menu : IMenu
    {
        public void run()
        {
            bool done = false;
            while (!done)
            {
                display();
                string selection = Console.ReadLine();
                int optionNumber;
                if (int.TryParse(selection, out optionNumber))
                {
                    if (optionNumber == quitOptionNumber())
                    {
                        done = true;
                    }
                    else
                    {
                        int optionIndex = optionNumber - 1;
                        if (options.Count > optionIndex)
                        {
                            options[optionIndex].select();
                        }
                    }
                }
            }
            
        }

        public Menu(List<IMenuOption> options)
        {
            this.options = options;
        }

        public Menu(List<IMenuOption> options, string prompt) : this(options)
        {
            this.prompt = prompt;
        }

        private string prompt;
        private List<IMenuOption> options;

        private void display()
        {
            if (prompt != null)
            {
                Console.WriteLine(prompt);
                Console.WriteLine();
            }
            int optionNumber = 0;
            foreach (IMenuOption option in options)
            {
                optionNumber++;

                string optionDisplay = getOptionDisplay(optionNumber, option.DisplayTitle);
                Console.WriteLine(optionDisplay);
            }
            displayQuitOption();
        }

        private string getOptionDisplay(int optionNumber, string displayTitle)
        {
            string optionNumberString = optionNumber.ToString();
            return optionNumberString + "." + displayTitle;
        }

        private void displayQuitOption()
        {
            int optionNumber = quitOptionNumber();
            const string QUIT = "Quit";
            string optionDisplay = getOptionDisplay(optionNumber, QUIT);
            Console.WriteLine(optionDisplay);
        }

        private int quitOptionNumber()
        {
            return options.Count + 1;
        }
    }
}
