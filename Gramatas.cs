using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;


class Gramatas
{

    // Klases lauki
    public string Book_Name;
    public string Book_Author;
    public string Book_Genre;
    public string BookGenrePubl;
    public int count;


    // Konstruktors
    public Gramatas(string Book_Name, string Book_Author, string Book_Genre, string BookGenrePubl, int count)
    {
        this.Book_Name = Book_Name;
        this.Book_Author = Book_Author;
        this.Book_Genre = Book_Genre;
        this.BookGenrePubl = BookGenrePubl;
        this.count = count;
    }

    // Metodes

    // Metode, kas kārto grāmatas pēc nosaukuma

    public static void SortName()
    {
        string filePath = "gramatas.csv";

        List<string[]> data = new List<string[]>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] elements = line.Split(',');
                data.Add(elements);
            }
        }

        // LINQ metode,kas sakārto elementus sarakstā pēc norādīta kritērija. 0 elements tiek ņemts kā kritērijs sakārtošanai.
        data = data.OrderBy(x => x[0]).ToList();

        foreach (string[] row in data)
        {
         
            Console.WriteLine("Grāmatas nosaukums: " + row[0] + "\nAutors: " + row[1] + "\nŽanrs: " + row[2] + "\nIzdevniecība: " + row[3] + "\nSkaits:" + row[4] + "\n");
        
          }
        Console.ReadLine();
    }

    // Metode, kas kārto grāmatas pēc autora
    public static void SortAuthor()
    {
        string filePath = "gramatas.csv";

        List<string[]> data = new List<string[]>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] elements = line.Split(',');
                data.Add(elements);
            }
        }

        // LINQ metode,kas sakārto elementus sarakstā pēc norādīta kritērija. Pirmais elements tiek ņemts kā kritērijs sakārtošanai.
        data = data.OrderBy(x => x[1]).ToList();

        foreach (string[] row in data)
        {
            Console.WriteLine("Grāmatas nosaukums: " + row[0] + "\nAutors: " + row[1] + "\nŽanrs: " + row[2] + "\nIzdevniecība: " + row[3] + "\nSkaits:" + row[4] + "\n");

        
          }
        Console.ReadLine();
    }

    // Metode, kas kārto grāmatas pēc žanra
    public static void SortGenre()
    {
        string filePath = "gramatas.csv";

        List<string[]> data = new List<string[]>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] elements = line.Split(',');
                data.Add(elements);
            }
        }
        // LINQ metode,kas sakārto elementus sarakstā pēc norādīta kritērija. Otrais elements tiek ņemts kā kritērijs sakārtošanai.
        data = data.OrderBy(x => x[2]).ToList();

        foreach (string[] row in data)
        {
            Console.WriteLine("Grāmatas nosaukums: " + row[0] + "\nAutors: " + row[1] + "\nŽanrs: " + row[2] + "\nIzdevniecība: " + row[3] + "\nSkaits:" + row[4] + "\n");
           
          }
        Console.ReadLine();
    }

    // Metode, kas izņem grāmatu no saraksta pēc nosaukuma
    public static void removeBook()
    {
        string filePath = "gramatas.csv";


        Console.WriteLine("Lūdzu, ievadiet grāmatas nosaukumu, kuru vēlaties dzēst:");
        string bookTitleToRemove = Console.ReadLine();


        List<string[]> data = new List<string[]>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] elements = line.Split(',');


                if (elements.Length > 0 && elements[0].Trim() != bookTitleToRemove)
                {
                    data.Add(elements);
                }
            }
        }
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string[] row in data)
            {
                sw.WriteLine(string.Join(",", row));
            }
        }

        Console.WriteLine("Grāmata veiksmīgi dzēsta!");
        Console.ReadLine();
    }

    // Metode, kas izņem grāmatu no saraksta pēc tās autora

    public static void removeBookbyAuthor()
    {
        string filePath = "gramatas.csv";
        Console.WriteLine("Lūdzu, ievadiet grāmatas autoru, kā kompozīciju vēlaties dzēst:");
        string bookAuthorToRemove = Console.ReadLine();

        // Izveido tukšu sarakstu, kurā tiks saglabātas atrastās grāmatas
        List<string[]> data = new List<string[]>();

        // Atver CSV failu un nolasa katru rindiņu
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // Katru rindu sadala pa komatiem un saglabā katru lauku
                string[] elements = line.Split(',');

                if (elements.Length > 0 && elements[1].Trim() != bookAuthorToRemove)
                {
                    data.Add(elements);
                }
            }
        }
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string[] row in data)
            {
                sw.WriteLine(string.Join(",", row));
            }
        }
        Console.WriteLine("Grāmata veiksmīgi dzēsta!");
        Console.ReadLine();
    }

    // Metode, kas pievieno jaunu grāmatu sarakstam
    public static void addBook()
    {
        string filePath = "gramatas.csv";
        Console.WriteLine("Lūdzu, ievadiet jaunās grāmatas datus - Nosaukums,Autors,Žanrs,Izdevniecība, skaitu: ");
        string newBookData = Console.ReadLine();

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(newBookData);
        }
        Console.WriteLine("Jaunā grāmata veiksmīgi pievienota!");
        Console.ReadLine();
    }


    // Metode, kas izvada visas grāmatas
    public static void DisplayBooks()
    {
        string filePath = "gramatas.csv";
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Split(','); 
                Console.WriteLine("Grāmatas nosaukums: " + fields[0] + "\nAutors: " + fields[1] + "\nŽanrs: " + fields[2] + "\nIzdevniecība: " + fields[3] + "\n Skaits:" + fields[4] + "\n");
              
              }
          }
    }

    
    // Metode, kas aizdod grāmatu lietotājam izvadot aizdošanas termiņu un samazinot savu skaitu par 1 vērtību
    public static void AizdotGramatu()
    {
        Gramatas.DisplayBooks();
        Console.WriteLine("Izvēlieties, kuru grāmatu vēlaties lasīt, ievadot tās nosaukum: ");
        string nosaukums = Console.ReadLine();

        string filePath = "gramatas.csv";

        // Izveido tukšu sarakstu, kurā tiks saglabātas atrastās grāmatas
        List<string[]> data = new List<string[]>();
        bool bookFound = false;

        // Atver CSV failu un nolasa katru rindiņu
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // Katru rindu sadala pa komatiem un saglabā katru lauku
                string[] fields = line.Split(',');

                // Pārbauda, vai grāmatas nosaukums sakrīt ar ievadīto un vai grāmatas pieejamais skaits ir lielāks par 0
                if (fields[0] == nosaukums && int.Parse(fields[4]) > 0)
                {

                    // Izvada aizdošanas datumu(šodienas)
                    DateTime dateTime = DateTime.UtcNow.Date;
                    Console.Write("Aizdošanas datums: ");
                    Console.WriteLine(dateTime.ToString("dd/MM/yyyy"));

                    // Izvada nodošanas termiņu pieskaitot pie aizdošanas datuma divas nedēļas
                    Console.Write("Nodošanas datums: ");
                    DateTime nodosanastermins = dateTime.AddDays(14);
                    Console.WriteLine(nodosanastermins.ToString("dd/MM/yyyy"));

                    // Samazina grāmatas pieejamo skaitu par 1
                    // Parse - pārverš no virknes uz skaitli, jo masīvā visi elementi ir virknes formātā
                    int skaits = int.Parse(fields[4]);
                    skaits--;
                    fields[4] = skaits.ToString();
                    bookFound = true;
                }
                data.Add(fields);
            }
        }
        if (!bookFound)
        {
            Console.WriteLine("Grāmata nav pieejama!");
        }

        // Visi dati tiek pārrakstīti atpakaļ CSV failā, atjauninot informāciju
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string[] row in data)
            {
                sw.WriteLine(string.Join(",", row));
            }
        }
    }


    // Metode, kas ļauj administratoram mainīt informāciju par grāmatu
    public static void EditBook()
    {
      
        string filePath = "gramatas.csv";
        Console.WriteLine("Ievadiet grāmatas nosaukumu, kuru vēlaties rediģēt: ");
        string nosaukums = Console.ReadLine();
        Console.WriteLine("Ievadiet, kuru lauku vēlaties rediģēt (1 - Nosaukumu, 2 -  Autoru, 3 - žanru, 4 - izdevniecību, 5 - skaitu): ");
        int newData = Convert.ToInt32(Console.ReadLine());
        string newNosaukums = "";
        string newAutors = "";
        string newZanrs = "";
        string newIzdevnieciba = "";
        string newSkaits = "";
        switch(newData)
        {
        case 1:
            Console.WriteLine("Ievadiet jauno nosaukumu: ");
            newNosaukums = Console.ReadLine();
            break;
        case 2:
            Console.WriteLine("Ievadiet jauno Autoru: ");
            newAutors = Console.ReadLine();
            break;
        case 3:
            Console.WriteLine("Ievadiet jauno Žanru: ");
            newZanrs = Console.ReadLine();
            break;
        case 4:
            Console.WriteLine("Ievadiet jauno izdevniecību: ");
            newIzdevnieciba = Console.ReadLine();
            break;
        case 5:
            Console.WriteLine("Ievadiet jauno skaitu: ");
            newSkaits = Console.ReadLine();
            break;
        default:
            Console.WriteLine("Nepareiza ievade!");
            break;
          }
      
        
        List<string> data = new List<string>();
        
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null){
                data.Add(line);
            }
          
        }
        
        string[] fields = data.First(x => x.Contains(nosaukums)).Split(',');
        
        if (fields.Length > 0)
        {
          if (newNosaukums.Length > 0)
          {
            fields[0] = newNosaukums;
          }
          else if (newAutors.Length > 0)
          {
            fields[1] = newAutors;
          }
          else if (newZanrs.Length > 0)
          {
            fields[2] = newZanrs;
          }
          else if (newIzdevnieciba.Length > 0)
          {
            fields[3] = newIzdevnieciba;
          }
          else if (newSkaits.Length > 0)
          {
            fields[4] = newSkaits;
          }
        }
      data.Remove(data.First(x => x.Contains(nosaukums)));
      data.Add(string.Join(",", fields));
      using (StreamWriter sw = new StreamWriter(filePath)){
        foreach (string row in data){
            sw.WriteLine(row);
        }
      }
    }
                    
    // Metode, kas meklē grāmatas pēc nosaukuma
    public static void SearchBookName()
    {
        string filePath = "gramatas.csv";
        Console.WriteLine("Ievadiet grāmatas nosaukumu, kuru vēlaties atrast: ");
        string searchName = Console.ReadLine();

         // Izveido tukšu sarakstu, kurā tiks saglabātas atrastās grāmatas
        List<string[]> matchingBooks = new List<string[]>();

        // Atver CSV failu un nolasa katru rindiņu
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // Katru rindu sadala pa komatiem un saglabā katru lauku
                string[] fields = line.Split(',');
                if (fields[0].Trim() == searchName)
                {
                    // Pievieno informāciju 
                    matchingBooks.Add(fields);
                }
            }
        }
        if (matchingBooks.Count > 0)
            {
                foreach (string[] book in matchingBooks)
                {
                    Console.WriteLine("\nGrāmatas nosaukums: " + book[0] + "\nAutors: " + book[1] + "\nŽanrs: " + book[2] + "\nIzdevniecība: " + book[3] + "\n Skaits:" + book[4] + "\n");
                }
            }
            else
            {
                Console.WriteLine("Nav atrastas grāmatas");
            }
        }

    // Metode, kas meklē grāmatas pēc žanra
    public static void SearchBookGenre()
    {
        string filePath = "gramatas.csv";
        Console.WriteLine("Ievadiet grāmatas žanru, kuru vēlaties atrast: ");
        string searchGenre = Console.ReadLine();

        // Izveido tukšu sarakstu, kurā tiks saglabātas atrastās grāmatas
        List<string[]> matchingBooks = new List<string[]>();

        // Atver CSV failu un nolasa katru rindiņu
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                 // Katru rindu sadala pa komatiem un saglabā katru lauku
                string[] fields = line.Split(',');
                if (fields[2].Trim() == searchGenre)
                {
                    // Pievieno informāciju 
                    matchingBooks.Add(fields);
                }
            }
        }

        if (matchingBooks.Count > 0)
        {
            foreach (string[] book in matchingBooks)
            {
                Console.WriteLine("\nGrāmatas nosaukums: " + book[0] + "\nAutors: " + book[1] + "\nŽanrs: " + book[2] + "\nIzdevniecība: " + book[3] + "\n Skaits:" + book[4] + "\n");
            }
        }
        else
        {
            Console.WriteLine("Nav atrastas grāmatas ar tādu žanru!");
        }
    }

    // Metode, kas meklē grāmatas pec autora
    public static void SearchBookAuthor()
    {
        string filePath = "gramatas.csv";
        Console.WriteLine("Ievadiet grāmatas autoru, kuru vēlaties atrast: ");
        string searchAuthor = Console.ReadLine();

        // Izveido tukšu sarakstu, kurā tiks saglabātas atrastās grāmatas
        List<string[]> matchingBooks = new List<string[]>();

        // Atver CSV failu un nolasa katru rindiņu
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {

                // Katru rindu sadala pa komatiem un saglabā katru lauku
                string[] fields = line.Split(',');

                // Trim - noņem atstarpes no teksta sākuma un beigām. Izmantots, lai noņemtu tukšumus no ievadītajiem datiem
                if (fields[1].Trim() == searchAuthor)
                {
                    // Pievieno informāciju 
                    matchingBooks.Add(fields);
                }
            }
        }
        if (matchingBooks.Count > 0)
        {
            foreach (string[] book in matchingBooks)
            {
                Console.WriteLine("\nGrāmatas nosaukums: " + book[0] + "\nAutors: " + book[1] + "\nŽanrs: " + book[2] + "\nIzdevniecība: " + book[3] + "\n Skaits:" + book[4] + "\n");
            }
        }
        else
        {
            Console.WriteLine("Nav atrastas grāmatas ar tādu autoru!");
        }
    }
}

