using System;
using System.Collections.Generic;


class Program
{
    
    static bool IrRegistrets = false;
    static List<User> userList = new List<User>();

    static void Main(string[] args)
    {
         Console.ForegroundColor = ConsoleColor.Blue;
        
        Console.WriteLine("Esiet sveicināts Latvijas Digitālajā bibliotēkā!");
        bool darb = true;
        while (darb)
        {
            if (IrRegistrets == false)
            {
                Console.WriteLine("\nKādu darbību jūs vēlaties veikt?");
                Console.WriteLine("1 - Reģistrēties profilā");
                Console.WriteLine("2 - Ielogoties profilā");


                string izvele = Console.ReadLine();
                if (izvele == "1")
                {
                    User.Registreties();
                    continue;
                }
                else if (izvele == "2")
                {
                    User.Ielogoties();
                    darb = false;
                }
                else
                
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(@"                    ___ _ __ _ __ ___  _ __ 
                   / _ \ '__| '__/ _ \| '__|
                  |  __/ |  | | | (_) | |   
                   \___|_|  |_|  \___/|_|   ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    Console.WriteLine("Mēģiniet vēlreiz!");
                   
                }
            }

        }
    }
}


