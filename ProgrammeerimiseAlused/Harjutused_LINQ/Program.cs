/*
Harjutused:
1. Loo massiiv 10 juhuslikust numbrist (1–50). Kasuta LINQ-d, et leida summa, keskmine, suurim ja väikseim number.
2. Loo loend 7 lemmikfilmiga. Filtreeri välja ainult filmid, mille nimi on pikem kui 6 tähemärki. Sorteeri tulemus tähestiku järjekorras.
3. Loo massiiv 10 õpilase hinnetega. Arvuta välja mitu õpilast on saanud vähemalt 4. Kasuta .Count() tingimusega.
4. Loo loend 5 linnaga. Muuda iga linna nimi suurtähtedeks ja prindi tulemus välja ühel real, komadega eraldatuna (string.Join).
*/

// Harjutus 1

using System.Linq;

int[] juhuslikudNumbrid = new int[10];

for (int i = 0; i < juhuslikudNumbrid.Length; i++)
{
    juhuslikudNumbrid[i] = new Random().Next(1, 51);
}

Console.WriteLine("Juhuslikud numbrid: " + string.Join(", ", juhuslikudNumbrid));
Console.WriteLine("Summa: " + juhuslikudNumbrid.Sum());
Console.WriteLine("Keskmine: " + juhuslikudNumbrid.Average());
Console.WriteLine("Suurim number: " + juhuslikudNumbrid.Max());
Console.WriteLine("Väikseim number: " + juhuslikudNumbrid.Min());

// Harjutus 2

// using System.Linq;

List<string> lemmikfilmid = new List<string> { "Saw", "Titanic", "Parasite", "The Godfather", "Wasp", "The Invite", "Obsession" };
List<string> pikadFilmid = new List<string>();

foreach (var film in lemmikfilmid)
{
    if (film.Length > 6)
    {
        pikadFilmid.Add(film);
    }
}

Console.WriteLine(string.Join(", ", pikadFilmid.OrderBy(t => t)));

// Harjutus 3

// using System.Linq;

int [] opilasteHinded = { 3, 4, 5, 2, 4, 5, 3, 4, 5, 2 };

int opilasteArv = opilasteHinded.Count(hinne => hinne == 4);
Console.WriteLine("Õpilaste arv, kes said hinde 4: " + opilasteArv);

// Harjutus 4

// using System.Linq;

List<string> linnad = new List<string> { "Tallinn", "Tartu", "Pärnu", "Kuressaare", "Viljandi" };

var suurtahtedegaLinnad = linnad.Select(linn => linn.ToUpper());
Console.WriteLine(string.Join(", ", suurtahtedegaLinnad));