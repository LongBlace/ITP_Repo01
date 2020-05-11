using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Hell_s_Warden
{
    class Teleporter
    {
        string Spell;
        ConsoleColor Color;

        public Teleporter(string spell, ConsoleColor color)
        {
            Spell = spell;
            Color = color;
        }

        public bool ReciteSpell()
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = Color;
            WriteLine("You appraoched the teleporter and stared blankly at it. How do I fix this thing? Hmm? What's this? \"In case of emergency recite the spell p-\" \nThe rest is burned off...");
            Write("Recite Spell: ");
            string playerAnswer = ReadLine().ToLower();
            if (playerAnswer == Spell)
            {
                WriteLine("You recited the spell and the teleporter repaired itself! For some reason you feel slightly disappointed that the spell worked... \nNow then let's go meet the Oracle!");
                ForegroundColor = previousColor;
                WriteLine("Press any key to continue...");
                ReadKey(true);
                Clear();
                return true;
            }
            else
            {
                WriteLine("Welp, back to the drawing board!");
                WriteLine("\n(press any key to continue...)");
                ReadKey(true);
                ForegroundColor = previousColor;
                return false;
            }




        }




    }
}
