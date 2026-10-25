/*
Harjutused:
1. Loo programm, mis küsib kasutajalt nime ja vanuse ning salvestab need faili kasutaja.txt. Kontrolli pärast programmi käivitamist, et fail ka tegelikult loodi.
2. Loo programm, mis loeb failist hinded.txt ja trükib konsoolile välja read, millel olev hinne on vähemalt 4.
3. Kirjuta programm päeviku pidamiseks: programm küsib sissekande teksti ja lisab selle faili paevik.txt lõppu (vana sisu peab alles jääma).
4. Loo programm, mis loeb failist opilased.txt nimede loendi (üks nimi real) ja sorteerib need tähestiku järjekorras enne välja trükkimist. Kasuta LINQ-d.
*/

// Harjutus 1

using System.IO;

namespace Users;

class Program
{
    static void Main(string[] args)
    {

        string kaust = @"C:\temp";

        if (!Directory.Exists(kaust))
        {
            Directory.CreateDirectory(kaust);
        }

        string tee = Path.Combine(kaust, "kasutajad.txt");

        Console.Write("Sisesta nimi: ");
        string nimi = Console.ReadLine();

        Console.Write("Sisesta vanus: ");
        string vanus = Console.ReadLine();

        string[] kasutaja =
        {
            nimi,
            vanus
        };

        File.WriteAllLines(tee, kasutaja);

        if (File.Exists(tee))
        {
            Console.WriteLine("Fail on olemas.");
        }
        else
        {
            Console.WriteLine("Faili ei ole.");
        }
    }
}

// Harjutus 2

using System.IO;

namespace Hinded;

class Program
{
    static void Main(string[] args)
    {
        string tee = @"C:\temp\hinded.txt";

        if (File.Exists(tee))
        {
            string[] read = File.ReadAllLines(@"C:\temp\hinded.txt");

            int[] hinded = read.Select(r => int.Parse(r)).ToArray();

            foreach (int hinne in hinded)
            {
                if (hinne >= 4)
                {
                    Console.WriteLine(hinne);
                }
            }
        }
        else
        {
            Console.WriteLine("Faili ei leitud.");
        }
    }
}

// Harjutus 3

using System.IO;

namespace Paevik;

class Program
{
    static void Main(string[] args)
    {

        string kaust = @"C:\temp";

        if (!Directory.Exists(kaust))
        {
            Directory.CreateDirectory(kaust);
        }

        string tee = Path.Combine(kaust, "paevik.txt");

        Console.Write("Loo päevikusse sissekanne: ");
        string sissekanne = Console.ReadLine();

        File.AppendAllText(tee, sissekanne + "\n");
    }
}

// Harjutus 4

using System.IO;
using System.Linq;

namespace Opilased;

class Program
{
    static void Main(string[] args)
    {
        string tee = @"C:\temp\opilased.txt";

        if (File.Exists(tee))
        {
            string[] nimed = File.ReadAllLines(tee);
            var sorteeritud = nimed.OrderBy(n => n);

            foreach (string nimi in sorteeritud)
            {
                Console.WriteLine(nimi);
            }
        }
        else
        {
            Console.WriteLine("Faili ei leitud.");
        }
    }
}

/*
// Faili kontrollimiseks
Console.WriteLine($"Kontrollitav fail: {tee}");
Console.WriteLine($"Kaustas olevad failid: {string.Join(", ", Directory.GetFiles(@"C:\temp"))}");
*/