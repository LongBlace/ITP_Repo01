using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
// Long Nguyen Intro to Programming 101 SP20
// Final Game Project - Hell's Warden
// 4/19/2020
// Al Liu helped me in making a main menu
// TODO: MORE ASCII ART, Code structuring / Clean up code for example PromptPressAnyKey, work on Player class, watch game architecture tutorial for ideas on how to structure multiple scenes.
// Maybe TODO: Writing, Colors, using / adding other methods or options such as another loop, bool etc...
namespace Hell_s_Warden
{
    class Game
    {

        public string GameTitle = "Hell's Warden";
        public string Description = "The year is 20XX. You are one of the seven Warden's of Hell that governs the seven Gates of Hell. " +
            "\nYou are tasked in protecting the First Gate of Hell which is closest to the Earth realm." +
            "\nAmong the seven Gates of Hell, there lies a powerful demon called Greyhawk that has been confined at the end of the seven gates." +
            "\nNews have reached your ear that he has escaped and injured the other wardens and is making his way to where you are and make it into the Earth realm!" +
            "\nShortly after, as your guard was down from the shock, he bursts through the ground, and the shockwave knocks you out." +
            "\nYou wake up to find everything in ruins and that Greyhawk has escaped! You must find the teleporter and go see the Oracle for guidance!";
        public string Art = @"
   )                                                              
 ( /(       (   (   (       (  (                  (                
 )\())   (  )\  )\  )\      )\))(   '    )  (     )\ )   (         
((_)\   ))\((_)((_)((_)(   ((_)()\ )  ( /(  )(   (()/(  ))\  (     
 _((_) /((_)_   _      )\  _(())\_)() )(_))(()\   ((_))/((_) )\ )  
| || |(_)) | | | |    ((_) \ \((_)/ /((_)_  ((_)  _| |(_))  _(_/(  
| __ |/ -_)| | | |    (_-<  \ \/\/ / / _` || '_|/ _` |/ -_)| ' \)) 
|_||_|\___||_| |_|    /__/   \_/\_/  \__,_||_|  \__,_|\___||_||_|  
                                                                  ";


        Player HellWarden;

        Objects TornPaper;
        Objects Document;
        Objects Blood;
        Objects Console;
        Teleporter DestroyedTeleporter;

        public Game()
        {
            TornPaper = new Objects("torn paper", "You could barely make out what it says, but it looks like it says \"doo doo\"...nah that can't be what it says.", ConsoleColor.White);
            Document = new Objects("document", "This document has the clue to repair the teleporter!\nIt says, \"We have invented a spell that can restore the teleporter when recited in the correct order just in case of an emer...\"\nThe Document got cut off...", ConsoleColor.Blue);
            Blood = new Objects("blood on the wall", "The blood spells out \"ka ka\"? What does that even mean?", ConsoleColor.Green);
            Console = new Objects("console", "The...the console just says \"pee pee\"... What kind of scientist did we hire?", ConsoleColor.Yellow);
            DestroyedTeleporter = new Teleporter("pee pee doo doo ka ka", ConsoleColor.Red);

            Title = "Hell's Warden by Long Nguyen";

            HellWarden = new Player();

        }
        public void StartGame()
        {
            CursorVisible = false;
            int desiredHeight = 30;
            int desiredWidth = 150;
            try
            {
                WindowHeight = desiredHeight;
                WindowWidth = desiredWidth;
            }
            catch(System.ArgumentOutOfRangeException)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("=== CODE RED ===");
                WriteLine("Hey! Sorry to scare you but your screen isn't big enough to match the game's desired height or width.");
                WriteLine("Thinks might look a bit wonky unless you adjust the text size of your console window. Sorry about that!");

                PromtPressAnyKey();
                ResetColor();
                Clear();

            }




            MainMenu();
            WriteLine("Press any key to exit...");
            ReadKey(true);

            //WriteLine($"You're good value = {HellWarden.GoodValue}.");

          
        }

        private void PromtPressAnyKey()
        {
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("Press any key to continue...");
            ForegroundColor = ConsoleColor.White;
            ReadKey(true);
        }

        static void PrintDivider()
        {
            WriteLine("\n======================================================================\n");
        }


        private void Intro()
        {
            BackgroundColor = ConsoleColor.DarkMagenta;
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine(Art);
            WriteLine(GameTitle);
            PrintDivider();
            ForegroundColor = ConsoleColor.White;
            WriteLine(Description);
            PrintDivider();

        }
        void InvalidInput()
        {
            ForegroundColor = ConsoleColor.White;
            WriteLine("Whoops, that's not it.");
            Write("\n(press any key to continue...) ");
            ReadKey(true);
        }
            string Explore()
        {

            ForegroundColor = ConsoleColor.White;
            WriteLine("\n\n----------------\n");
            WriteLine("Where should we start looking?");
            WriteLine("  1) a torn paper\n  2) a document\n  3) a blood message\n  4) a console\n  5) a teleporter");
            string answer = ReadLine();
            WriteLine("\n----------------\n\n");
            return answer;


        }

        private void MainMenu() 
        {
            
            
            string prompt = @"
(       (   (   (       (  (                  (                
 )\())   (  )\  )\  )\      )\))(   '    )  (     )\ )   (         
((_)\   ))\((_)((_)((_)(   ((_)()\ )  ( /(  )(   (()/(  ))\  (     
 _((_) /((_)_   _      )\  _(())\_)() )(_))(()\   ((_))/((_) )\ )  
| || |(_)) | | | |    ((_) \ \((_)/ /((_)_  ((_)  _| |(_))  _(_/(  
| __ |/ -_)| | | |    (_-<  \ \/\/ / / _` || '_|/ _` |/ -_)| ' \)) 
|_||_|\___||_| |_|    /__/   \_/\_/  \__,_||_|  \__,_|\___||_||_|  
                                                                  
Welcome to Hell's Warden! What would you like to do?
(You can use the up and down arrow keys to cycle through your options! 
 Once you've hovered on the option, press ENTER to select an option!)";
            string[] options = { "Play Game", "Credits", "Exit"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();


                switch (selectedIndex)
                {
                    case 0:
                        PlayGame();
                        break;

                    case 1:
                        Credits();
                        break;

                    case 2:
                        Exit();
                        break;

                }


         

        }

        private void PlayGame()
        {
            bool hasTeleported = false;
            Intro();
            WriteLine("You have arrived at the laboratory where the Teleporter is, only to find it in shambles and everyone is dead!");
            WriteLine("\nSurely there's some sort of clue on how to repair the teleporter or something in this room!");
            Write("\n(press any key to continue...) ");
            ReadKey(true);

            while (!hasTeleported)
            {
                string answer = Explore();

                if (answer == "1")
                {
                    TornPaper.ExamineObject();
                }
                else if (answer == "2")
                {
                    Document.ExamineObject();
                }
                else if (answer == "3")
                {
                    Blood.ExamineObject();
                }
                else if (answer == "4")
                {
                    Console.ExamineObject();
                }
                else if (answer == "5")
                {
                    hasTeleported = DestroyedTeleporter.ReciteSpell();
                }
                else
                {
                    InvalidInput();
                }

            }

            WriteLine("You have teleported in front of the palace where the Oracle resides.");
            WriteLine("But suddenly the front entrance blows up and knocks you back! ");
            WriteLine("Oh no the Oracle! You recover from the knockback and head towards the explosion.");
            WriteLine("In the smoke you spot Athena, one of the Seven Wardens of Hell, being pinned down by a blood hound!");
            string prompt = "What should you do?";
            PrintDivider();
            string[] options = { "1)She's got this! She isn't one of the Wardens of Hell for nothing!","2)Oh no she's in danger! I should help her out!" };
            Menu firstChoice = new Menu(prompt, options);
            int selectedIndex = firstChoice.RunPrompt();

            
            switch (selectedIndex)
            {
                case 0:
                    // Dialogue for bad choice
                    HellWarden.GoodValue -= 1;
                    PrintDivider();
                    WriteLine("I'm sure she'll be fine!\"You run right past her and head towards the palace to find the Oracle!\"");
                    PromtPressAnyKey();
                    WriteLine("You arrived at the door but it was locked, you felt something flying towards you and dodged it. \nAfter the flying object destroyed the door, it appears that it was the blood hound that got sent flying.");
                    PromtPressAnyKey();
                    WriteLine("Athena approaches you and says,");
                    WriteLine("Athena: Thanks for the help ass hat.");
                    PromtPressAnyKey();
                    WriteLine("You: Sorry! I thought you had it under control!");
                    PromtPressAnyKey();
                    WriteLine("Athena: Hmph! Whatever. You're lucky we're in a hurry, otherwise, you'd be dead meat! Now then, let's hurry up and find the Oracle.");
                    PromtPressAnyKey();
                    WriteLine("You: R-right!");
                    PromtPressAnyKey();
                    Clear();
                    break;

                case 1:
                    // Dialogue for good choice
                    HellWarden.GoodValue += 1;
                    PrintDivider();
                    WriteLine("You decided to help her and ran towards her! You sprinted as fast as you could and drop kicked the blood hound into the wall, killing it on impact.");
                    PromtPressAnyKey();
                    WriteLine("You: Athena! Are you okay? \nYou reached for her hand and she grabs it");
                    PromtPressAnyKey();
                    WriteLine("Athena: That was a close one! Thanks for the help.");
                    PromtPressAnyKey();
                    WriteLine("You: Don't sweat it! You would have done the same. Quick let's hurry to the Oracle!");
                    PromtPressAnyKey();
                    WriteLine("Athena: I'm right behind you!");
                    PromtPressAnyKey();
                    WriteLine("You both approached the door.");
                    PromtPressAnyKey();
                    WriteLine("You: Darn, it's locked! What do we do now!");
                    PromtPressAnyKey();
                    WriteLine("Athena: Ahem! \nShe points at the big ass hole in the wall right next to the door");
                    PromtPressAnyKey();
                    WriteLine("You: Oh... \nAfter making a poker face, you both went through the hole in the wall and went to find the Oracle.");
                    PromtPressAnyKey();
                    Clear();
                    break;

  

            }

            // I'm trying to avoid branching as much as possible, so after every outcome (good or bad choices), 
            // it will arrive at the same conclusion (with the except the outcome of the ending via good values)
            WriteLine("You both find the Oracle, but something is strange about him");
            PromtPressAnyKey();
            WriteLine("Oracle: Ayyyy wazz up my homies, it'z bout timez ya found me.");
            PromtPressAnyKey();
            WriteLine("You:???????");
            PromtPressAnyKey();
            WriteLine("Athena:???????");
            PromtPressAnyKey();

            WriteLine("To be continued...");

            PrintDivider();
            WriteLine("Thanks for playing Hell's Warden!\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);


        }

        private void Credits()
        {
            //HellWarden.GoodValue += 1;
            //WriteLine($"You're good value = {HellWarden.GoodValue}.");
            WriteLine("\nGame is inspired by a japanese manga called Hell Warden Higuma, programming is done by Long Nguyen, 2020");
            WriteLine("Life Savers: Michael Hadley, Al Liu");
            WriteLine("\nPress any key to return to the Main Menu...");
            MainMenu();
        }

        private void Exit()
        {
            //method call to close the console window 
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }




    }






}
