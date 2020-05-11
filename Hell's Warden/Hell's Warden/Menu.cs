using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Hell_s_Warden
{
    class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;

        }

        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;


                if (i == SelectedIndex)
                {
                    prefix = ">";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }


                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
            
        }

        private void DisplayPrompt()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;


                if (i == SelectedIndex)
                {
                    prefix = ">";
                    //ForegroundColor = ConsoleColor.DarkMagenta;
                    //BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    //ForegroundColor = ConsoleColor.White;
                    //BackgroundColor = ConsoleColor.DarkMagenta;
                }


                WriteLine($"{prefix} << {currentOption} >>");
            }

            //ForegroundColor = ForegroundColor;
            //BackgroundColor = BackgroundColor;
        }

            public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }



        public int RunPrompt()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayPrompt();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }














    }
}
