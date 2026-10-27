/*
Harjutused:
1. Loo programm, mis mõõdab Stopwatch-iga, kui kaua võtab aega arvude 1 kuni 10000 summa arvutamine for-tsükliga. Kuva tulemus konsoolile watch.Elapsed abil. Proovi hiljem sama arvutust teha ka 100000 arvuga ja võrdle, kui palju aega juurde tuli.
2. Kleebi oma projekti peatükis olevad kaks näidet — File.AppendLine()-ga ja streami klassidega logifaili kirjutamine. Loo ~100000 kande teisene logifail mõlema variandiga ja mõõda mõlema kulgemist. Kirjuta tulemused üles ja mõõda veel teine kord — kas tulemused on sarnased?
3. Võrdle kaht mõõteviisi: mõõda sama väga kiire operatsioon (näiteks i * 2 100000 korda) kõigepealt DateTime.Now lahutamisega ja siis Stopwatch-iga. Proovi mõlemat mõõtmist mitu korda ja vaata, kui palju tulemused erinevad. Sellest on hea näha, miks Stopwatch usaldusväärsem on.
4. Kirjuta programm, mis testib puhverdamist: kirjuta StreamWriter-iga faili 10000 rida. Mõõda, kui kaua see aega võtab, kui puhver lastakse iga 1000 rea järel tühjaks writer.Flush()-iga, ja võrdle aega variandiga, kus Flush()-i ei kasuta.
5. Sama ülesanne mitu korda: pane ühe tsükli sisse mõõtmine nii, et programm mõõdab sama ülesande täitmise 5 korda ning jagab kogu aja 5-ga. Nii saame ülesande keskmise kestuse, mis on täpsem kui üksainus mõõtmine. (Vihje: hoia igal ringil Stopwatch eraldi või kasuta watch.Restart().)
*/

// Harjutus 1

using System;
using System.IO;
using System.Diagnostics;

namespace Sum;

class Program
{
    static void Main(string[] args)
    {
        var watch = new Stopwatch();
        int summa = 0;

        watch.Start();

        for (var i = 0; i <= 10000; i++)
        {
            summa += i;
        }

        watch.Stop();

        // Console.WriteLine("Summa 1..10000: " + summa);
        Console.WriteLine("Aega läks: " + watch.Elapsed); // 00:00:00.0000166 vs 00:00:00.0000558 (vahe 39,2 us)
    }
}


// Harjutus 2
// Katse 1: File.AppendAllText() ajakulu 00:00:26.4855263 & StreamWriter() ajakulu 00:00:00.0057356
// Katse 2: File.AppendAllText() ajakulu 00:00:13.9366548 & StreamWriter() ajakulu 00:00:00.0057276

using System.Diagnostics;
using System.IO;

namespace FileAppendApp;

class Program
{
    static void Main(string[] args)
    {
        var watch = new Stopwatch();
        var fileName = @"C:\temp\AppendAllText_log.txt";

        watch.Start();

        for (var i = 0; i < 100000; i++)
        {
            File.AppendAllText(fileName, (i + 1) + Environment.NewLine);
        }

        watch.Stop();

        Console.WriteLine("Aega läks: " + watch.Elapsed);
    }
}

using System.Diagnostics;
using System.IO;

namespace StreamWriterApp;

class Program
{
    static void Main(string[] args)
    {
        var watch = new Stopwatch();
        var fileName = "StreamWriter_log.txt";

        using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
        using (var writer = new StreamWriter(fileStream))
        {
            watch.Start();

            for (var i = 0; i < 100000; i++)
            {
                writer.WriteLine(i + 1);
            }

            watch.Stop();
        }
        Console.WriteLine("Aega läks: " + watch.Elapsed);
    }
}


// Harjutus 3

// Testin for tsükliga
// Katse 1: DateTime.Now: 00:00:00.0035379 / Stopwatch: 00:00:00.0000466
// Katse 2: DateTime.Now: 00:00:00.0040210 / Stopwatch: 00:00:00.0001291

using System.Diagnostics;
using System.IO;

namespace DateTimeNowApp;

class Program
{
    static void Main(string[] args)
    {
        int tulemus = 0;
        var watch = new Stopwatch();
        watch.Start();
        //var algus = DateTime.Now;

        for (int i = 0; i < 100000; i++)
        {
            tulemus = i * 2;
        }

        watch.Stop();
        //var lõpp = DateTime.Now;

        Console.WriteLine("Aega läks: " + watch.Elapsed);
        //Console.WriteLine("Aega läks: " + (lõpp - algus));
    }
}

// Testin while tsükliga
// Katse 1: DateTime.Now: 00:00:00.0030758 / Stopwatch: 00:00:00.0000444
// Katse 2: DateTime.Now: 00:00:00.0038426 / Stopwatch: 00:00:00.0001473

using System.Diagnostics;
using System.IO;

namespace StopwatchApp;

class Program
{
    static void Main(string[] args)
    {
        int i = 0;
        int tulemus = 0;
        var watch = new Stopwatch();
        watch.Start();
        //var algus = DateTime.Now;

        while (i <= 100000)
        {
            tulemus = i * 2;
            i++;
        }

        watch.Stop();
        //var lõpp = DateTime.Now;

        Console.WriteLine("Aega läks: " + watch.Elapsed);
        //Console.WriteLine("Aega läks: " + (lõpp - algus));
    }
}


// Harjutus 4
// Kasutades writer.Flush() kulus aega 00:00:00.0009117 / Mitte kasutades writer.Flush() kulus aega 00:00:00.0007999

using System.Diagnostics;
using System.IO;

namespace StreamWriterFlushApp;

class Program
{
    static void Main(string[] args)
    {
        var watch = new Stopwatch();
        var fileName = @"C:\temp\StreamWriter_log.txt";

        using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
        using (var writer = new StreamWriter(fileStream))
        {
            watch.Start();

            for (var i = 0; i < 10000; i++)
            {
                writer.WriteLine(i + 1 + " rida");

                if ((i + 1) % 1000 == 0)
                {
                    writer.Flush();
                }

            }

            watch.Stop();
        }
        Console.WriteLine("Aega läks: " + watch.Elapsed);
    }
}


// Harjutus 5

using System.Diagnostics;
using System.IO;

namespace StreamWriterApp;

class Program
{
    static void Main(string[] args)
    {
        var fileName = @"C:\temp\StreamWriter_log.txt";
        int katseteArv = 5;
        TimeSpan koguAeg = TimeSpan.Zero;

        for (var katse = 1; katse <= katseteArv; katse++)
        {
            var watch = Stopwatch.StartNew();

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            using (var writer = new StreamWriter(fileStream))
            {
                for (var rida = 0; rida < 10000; rida++)
                {
                    writer.WriteLine(rida + 1 + " rida");
                }
            }

            watch.Stop();
            koguAeg += watch.Elapsed;
            Console.WriteLine("Katse " + katse + " : " + watch.Elapsed);
        }

        var keskmineAeg = koguAeg / katseteArv;
        Console.WriteLine("Keskmine aeg: " + keskmineAeg);
    }
}
