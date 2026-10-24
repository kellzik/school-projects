/*
Harjutused:
1. Loo klass Päevik, mis implementeerib IDisposable. Konstruktor trükib "Päevik avatud" ja Dispose() trükib "Päevik suletud". Kasuta klassi using-klausliga ja veendu, et mõlemad teated ilmuvad õiges järjekorras.
2. Täienda harjutuse 1 klassi meetodiga Lisa(string tekst), mis prindib lisatava rea. Lisa using-ploki sees kolm rida ja vaata, millal täpselt "Päevik suletud" välja tuleb.
3. Kirjuta sama programm kaks korda: üks kord kasutades using-klauslit ja teine kord kutsudes Dispose() käsitsi. Selgita kommentaarides, milline variant on turvalisem ja miks.
4. Loo kaks erinevat vabastatavat klassi, näiteks Andmebaas ja Logi, mis mõlemad implementeerivad IDisposable. Kasuta neid ühes using-lauses ja veendu, et mõlemad vabastatakse. Jälgi, millises järjekorras Dispose() meetodid välja kutsutakse.
*/

// Harjutus 1
using System;

namespace Harjutused_IDisposable
{
    public class Päevik : IDisposable
    {
        public Päevik()
        {
            Console.WriteLine("Päevik avatud");
        }

        public void Dispose()
        {
            Console.WriteLine("Päevik suletud");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var p = new Päevik())
            {
            }
        }
    }
}

// Harjutus 2
using System;

namespace Harjutused_IDisposable
{
    public class Päevik : IDisposable
    {
        public Päevik()
        {
            Console.WriteLine("Päevik avatud");
        }

        public void Lisa(string tekst)
        {
            Console.WriteLine($"Lisatud: {tekst}");
        }

        public void Dispose()
        {
            Console.WriteLine("Päevik suletud");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var p = new Päevik())
            {
                p.Lisa("Esimene rida");
                p.Lisa("Teine rida");
                p.Lisa("Kolmas rida");
            }
        }
    }
}

// Harjutus 3

using System;

namespace Harjutused_IDisposable
{
    public class Päevik : IDisposable
    {
        public Päevik()
        {
            Console.WriteLine("Päevik avatud");
        }

        public void Lisa(string tekst)
        {
            Console.WriteLine($"Lisatud: {tekst}");
        }

        public void Dispose()
        {
            Console.WriteLine("Päevik suletud");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var p = new Päevik())
            {
                p.Lisa("Esimene rida");
                p.Lisa("Teine rida");
                p.Lisa("Kolmas rida");
            }

            ManualDispose(); // Käivitan ManualDispose() meetodi. See on ühtlasi vähem turvaline võrreldes using lausega, sest kui enne Dispose() välja kutsumist peaks viga tekkima ja kood katkema, siis jääb ressurss vabastamata, sest Dispose() rida ei käivitatud.
        }

        static void ManualDispose()
        {
            var p = new Päevik();
            p.Lisa("Esimene rida");
            p.Lisa("Teine rida");
            p.Lisa("Kolmas rida");
            p.Dispose();
        }
    }
}

// Harjutus 4

using System;

namespace Harjutused_IDisposable
{
    public class Andmebaas : IDisposable
    {
        public Andmebaas()
        {
            Console.WriteLine("Andmebaas avatud");
        }

        public void Dispose()
        {
            Console.WriteLine("Andmebaas suletud");
        }
    }

    public class Logi : IDisposable
    {
        public Logi()
        {
            Console.WriteLine("Logi avatud");
        }

        public void Dispose()
        {
            Console.WriteLine("Logi suletud");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (IDisposable andmebaas = new Andmebaas(), logi = new Logi())
            {
            }
        }
    }
}