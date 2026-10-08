/*
Harjutused:
1. Kirjuta programm, mis defineerib muutujad oma nime, vanuse, sünniaasta ja lemmiktoitude kohta ning kuvab need ekraanile.
2. Mõtle välja kolm muutujat, mida võiksid kasutada oma koolipäeva kirjeldamiseks. Defineeri need ja kuva väärtused.
3. Defineeri konstandid päikese läbimõõdu (km), maa päikese ümber tiirlemise aja (päeva) ja valguse kiiruse (km/s) kohta.
*/

// Harjutus 1

using System.Text;

string nimi = "Kelly";
int vanus = 33;
int synniaasta = 1992;
string[] lemmiktoidud = { "pasta", "hapukapsas", "kaneelirull" };

Console.WriteLine("Nimi: " + nimi);
Console.WriteLine("Vanus: " + vanus);
Console.WriteLine("Sünniaasta: " + synniaasta);
Console.WriteLine("Lemmiktoidud: " + lemmiktoidud[0] + ", " + lemmiktoidud[1] + ", " + lemmiktoidud[2]);

/*
// Kasutades string.Join meetodit:
Console.WriteLine(string.Join(", ", lemmiktoidud));

// Kasutades foreach tsüklit:
foreach (string toit in lemmiktoidud)
{
    Console.WriteLine(toit);
}
*/

// Harjutus 2

int tundideArv = 6;
string lemmiktund = "Matemaatika";
int kontrolltöödeArv = 1;

Console.WriteLine("Tundide arv: " + tundideArv);
Console.WriteLine("Lemmiktund: " + lemmiktund);
Console.WriteLine("Kontrolltööde arv: " + kontrolltöödeArv);

// Harjutus 3

const int PaikeseLabimoot = 1392000; //km
const int MaaTiirlemiseAeg = 365; //päeva
const int ValguseKiirus = 299792; //km/s

/*
Console.WriteLine("Päikese läbimõõt: " + PaikeseLabimoot + " km");
Console.WriteLine("Maa tiirlemise aeg ümber päikese: " + MaaTiirlemiseAeg + " päeva");
Console.WriteLine("Valguse kiirus: " + ValguseKiirus + " km/s");
*/