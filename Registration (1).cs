using System;
using System.Collections.Generic;


public static class Registration
{

    // Metode, kas izviedo lietotāju un saglabā to datubāzē
    public static void RegisterUser(List<User> userList)
    {

        Console.WriteLine("\nReģistrācija\n");

        while (true)
        {

            Console.Write("Lietotājvārds: ");
            string lietotajvards = Console.ReadLine();


            if (!validateUsername(lietotajvards))
            {
                Console.WriteLine("Lietotājvārds neatbilst nosacījumiem!");
                continue;

            }


            Console.Write("Parole: ");
            string parole = Console.ReadLine();


            if (!validatePasword(parole))
            {
                Console.WriteLine("Parole neatbilst nosacījumiem");
                continue;

            }


            User user = new User(lietotajvards, parole);
            userList.Add(user);
            Console.WriteLine("\nReģistrācija veiksmīga!\n");
            break;
            
        }
    }


    // Metode, kas pārbauda, vai parole atbilst noteiktiem nosacījumiem
    private static Boolean validatePasword(string password)
    {
        char[] numbers = new char[]{
      '1','2','3','4','5','6','7','8','9','9'
    };
        if (password.Length >= 8)
        {
            foreach (char c in numbers)
            {
                if (password.Contains(c))
                {
                    return true;
                }
            }
        }
        return false;
    }



  // Metode, kas pārbauda, vai lietotājvārds atbilst noteiktiem nosacījumiem
    private static Boolean validateUsername(string user)
    {

        if (!validatePasword(user))
        {
            return false;
        }

        foreach (char a in user)
        {
            if (a == char.ToUpper(a))
            {
                return true;
            }
        }
        return false;
    }
}
