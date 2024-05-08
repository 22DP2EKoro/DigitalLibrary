using System;
using System.Collections.Generic;
using System.IO;


public class User
{
    
    static List<User> userList = new List<User>();
    public String lietotajvards;
    public String parole;
    public static void add(String user)
    {
    }
    public User(string lietotajvards, string parole)
    {
        this.lietotajvards = lietotajvards;
        this.parole = parole;
    }

    // Metode, kas pārbauda, vai ievadītais lietotājvārds un parole jau ir reģistrēti
    public static bool Check(string lietotajvards, string parole)
    {

        // Atver CSV failu un nolasa katru rindiņu
        using (StreamReader reader = new StreamReader("Lietotajs.csv"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Katru rindu sadala pa komatiem un saglabā katru laukU
                string[] fields = line.Split(',');
                // Pārbauda, rindiņa satur tieši divi lauki un vai šie lauki ir vienādi ar ievadītajiem lietotājvārdu un paroli
                if (fields.Length == 2 && fields[0] == lietotajvards && fields[1] == parole)
                {
                    return true;
                }
            }
            return false;
        }
    }


    // Metode, kas dod iespēju lietotājiem ielogoties programmā
    public static void Ielogoties()
    {
        Console.Write("Ievadiet lietotājvārdu: ");
        string lietotajvards = Console.ReadLine();
        Console.Write("Ievadiet paroli: ");
        string parole = Console.ReadLine();

        if (Check(lietotajvards, parole))
        {

            Console.WriteLine("\nVeiksmīgi!\n");
            DarbibuIzvele();
        }
        else
        {
            if (lietotajvards == "admin" && parole == "admin")
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nAdministrators\n");
                Console.WriteLine("1 - Pievienot grāmatu\n2 - Dzēst grāmatu\n3 - Rediģēt grāmatas infromāciju");
                string izvele = Console.ReadLine();
                if (izvele == "1")
                {
                    Gramatas.addBook();
                }
                else if (izvele == "2")
                {
                    Console.WriteLine("1 - Dzēst grāmatu pēc nosaukuma\n2 - Dzēst grāmatu pēc autora\n3 - Rediģēt informāciju par grāmatu");
                    string izvele2 = Console.ReadLine();
                    if (izvele2 == "1")
                    {
                        Gramatas.removeBook();
                    }
                    else if (izvele2 == "2")
                    {
                        Gramatas.removeBookbyAuthor();
                    }
                }
                else if (izvele == "3")
                {
                    Gramatas.EditBook();
                }
            }
            else
            {

                Console.WriteLine("Nepareiza ievade. Mēģiniet vēlreiz!");
                Ielogoties();
            }
        }
    }

    // Metode, kas piedāvā lietotājiem izvēlēties starp vairkākām darbībām
    public static void DarbibuIzvele()
    {
        Console.WriteLine();
        Console.WriteLine("1 - Skatīt grāmatas\n2 - Kārtot grāmatas\n3 - Meklēt grāmatas\n4 - Paņemt grāmatu lasīšanai");
        string izvele = Console.ReadLine();
        if (izvele == "1")
        {
            Console.WriteLine();
            Gramatas.DisplayBooks();
            DarbibuIzvele();
          
        }
        else if (izvele == "2")
        {
            Console.WriteLine();
            Kartosana();
           DarbibuIzvele();
          
         
        }
        else if (izvele == "3")
        {
            Console.WriteLine();
            Console.WriteLine("1 - Meklēt grāmatas pēc nosaukuma\n2 - Meklēt grāmatas pēc žanra\n3 - Meklēt grāmatas pēc autora");
            string izvele2 = Console.ReadLine();
            if (izvele2 == "1")
            {
                Console.WriteLine();
                Gramatas.SearchBookName();
                
              DarbibuIzvele();
            }
            else if (izvele2 == "2")
            {
                Console.WriteLine();
                Gramatas.SearchBookGenre();
                
              DarbibuIzvele();
            }
            else if (izvele2 == "3")
            {
                Console.WriteLine();
                Gramatas.SearchBookAuthor();
              DarbibuIzvele();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Nepareiza ievade!");
            }
        }
        else if (izvele == "4")
        {
            Console.WriteLine();
            Gramatas.AizdotGramatu();
            DarbibuIzvele();
        }
        else
        {
            Console.WriteLine("Nepareiza ievade. Mēģiniet vēlreiz!");
            DarbibuIzvele();
        }
    }




    // Metode, kas piedāvā lietotājiem kārtot grāmatas pēc vairākiem kritērijiem
    public static void Kartosana()
    {
        Console.WriteLine("A - Kārtot grāmatas pēc nosaukuma");
        Console.WriteLine("B - Kārtot grāmatas pēc autora");
        Console.WriteLine("C - Kārtot grāmatas pēc žanra");

        string sort = Console.ReadLine();
        if (sort == "A")
        {
            Gramatas.SortName();
            DarbibuIzvele();
        }
        else if (sort == "B")
        {
            Gramatas.SortAuthor();
          DarbibuIzvele();

        }
        else if (sort == "C")
        {

            Gramatas.SortGenre();
         
        }
        else
        {
            Console.WriteLine("Nepareiza ievade! Mēģiniet vēlreiz!");
          Kartosana();
        }
    }

    // Metode, kas saglabā lieotājvārdu un paroli failā
    public static void SaveUsersToCSV(string fileName, List<User> users)
    {
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            foreach (var user in users)
            {
                writer.WriteLine($"{user.lietotajvards},{user.parole}");
            }
        }
        Console.WriteLine("Lietotājs veiksmīgi saglabāts datubāzē!");

    }

    public static void Registreties()
    {
        Registration.RegisterUser(userList);
        
        SaveUsersToCSV("Lietotajs.csv", userList);
    }  
}
