/*
Harjutused:
1. Loo programm, mis kirjutab logifaili log.txt programmi käivitamise ja lõpetamise aja. Kasuta StreamWriter-it koos FileMode.Append või true parameetriga ja DateTime.Now kuupäevaga, et päevik oleks täidetav mitu korda ilma vana sisu kaotamata.
2. Kirjuta programm, mis loeb StreamReader-iga ridade kaupa faili linnad.txt ja trükib iga linna koos reanumbriga: 1. Tallinn, 2. Tartu jne.
3. Loo programm, mis küsib kasutajalt üksteise järel sõnu ja salvestab need ridade kaupa faili sonad.txt. Küsimine lõpeb, kui kasutaja sisestab sõna lõpp.
4. Kirjuta programm, mis loeb faili programmi.log rea kaupa ja trükib välja ainult read, mis algavad ERROR — nii saame logist vead välja filtreerida.
5. Loo koopiaprogramm: programm loeb faili allikas.txt rea kaupa StreamReader-iga ja kirjutab need StreamWriter-iga faili koopia.txt. Kasuta mõlema jaoks using-lauset. Faili lõpus ütle, mitu rida kopeeriti.
*/

// Harjutus 1
/*
using System;
using System.IO;

namespace Linnad;

class Program
{
    static void Main(string[] args)
    {
        DateTime kaivitamiseAeg = DateTime.Now;
        string kaust = @"C:\temp";

        if (!Directory.Exists(kaust))
        {
            Directory.CreateDirectory(kaust);
        }

        string tee = Path.Combine(kaust, "log.txt");
        
        using (StreamWriter kirjutaja = new StreamWriter(tee, true))
        {
            kirjutaja.WriteLine("Programm käivitus: " + kaivitamiseAeg);
            kirjutaja.WriteLine("Programm lõppes: " + DateTime.Now);
        }  
    }
}

// Harjutus 2

using System;
using System.IO;

namespace Log;

class Program
{
    static void Main(string[] args)
    {
        string tee = @"C:\temp\linnad.txt";

        if (File.Exists(tee))
        {
            using (StreamReader lugeja = new StreamReader(tee))
            {
                string linn;
                int reaNr = 1;

                while ((linn = lugeja.ReadLine()) != null)
                {
                    Console.WriteLine(reaNr + ". " + linn);
                    reaNr++;
                }
            }
        }
    }
}

// Harjutus 3

using System;
using System.IO;

namespace Sonad;

class Program
{
    static void Main(string[] args)
    {
        string kaust = @"C:\temp";

        if (!Directory.Exists(kaust))
        {
            Directory.CreateDirectory(kaust);
        }

        string tee = Path.Combine(kaust, "sonad.txt");

        while (true)
        {
            Console.Write("Lisa sõna (lopp lõpetab): ");
            string sona = Console.ReadLine();

            if (sona == "lopp")
            {
                break;
            }
            else
            {
                using (StreamWriter kirjutaja = new StreamWriter(tee, true))
                {
                    kirjutaja.WriteLine(sona);
                }
            }
        }
    }
}

// Harjutus 4

using System;
using System.IO;

namespace LogReader;

class Program
{
    static void Main(string[] args)
    {
        string tee = @"C:\temp\programmi.log";

        if (File.Exists(tee))
        {
            using (StreamReader lugeja = new StreamReader(tee))
            {
                string err = "ERROR";
                string rida;

                while ((rida = lugeja.ReadLine()) != null)
                {
                    if (rida.Contains(err))
                    {
                        Console.WriteLine(rida);
                    }
                }
            }
        }
    }
}
*/
// Harjutus 5

using System;
using System.IO;

namespace Koopia;

class Program
{
    static void Main(string[] args)
    {
        string teeAllikas = @"C:\temp\allikas.txt";
        string teeKoopia = @"C:\temp\koopia.txt";

        if (File.Exists(teeAllikas))
        {
            using (StreamReader lugeja = new StreamReader(teeAllikas))
            {
                string rida;
                int ridadeArv = 0;

                while ((rida = lugeja.ReadLine()) != null)
                {
                    using (StreamWriter kirjutaja = new StreamWriter(teeKoopia, true))
                    {
                        kirjutaja.WriteLine(rida);
                        ridadeArv++;
                    }
                }
                File.AppendAllText(teeKoopia, "Kopeeritud ridu: " + ridadeArv);
            }
        }
    }
}