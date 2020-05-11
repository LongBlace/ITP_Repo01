using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Hell_s_Warden
{
    class Objects
    {

        string Name;
        string Description;
        ConsoleColor Color;

        public Objects(string name, string description, ConsoleColor color)
        {
            Name = name;
            Description = description;
            Color = color;

        }

        public void ExamineObject()
        {
            ForegroundColor = Color;
            WriteLine($"You examined the {Name}.");
            WriteLine(Description);
            Write("\n(press any key to continue...) ");
            ReadKey(true);
        }




    }



}
