/*
Harjutused:
1. Kirjuta programm, mis kasutab while tsüklit ja trükib arvud 1 kuni 10 kasvavas järjekorras.
2. Kirjuta programm, mis kasutab for tsüklit ja trükib tagurpidi arvud 10 kuni 1.
3. Arvuta for tsükliga kõikide paarisarvude summa vahemikus 1 kuni 50.
4. Loo massiiv oma lemmiklaulude nimedega ja trüki need foreach tsükliga ekraanile.
5. Loo loend arvudest ja leia foreach tsükliga nii nende summa kui ka suurim element.
6. Küsi kasutajalt while tsüklis arve seni, kuni ta sisestab 0. Seejärel trüki sisestatud arvude summa.
7. Kirjuta programm, mis trükib for tsükliga korrutustabeli arvule 7 (7 × 1 kuni 7 × 10).
8. Kasuta break-i, et leida esimene arv vahemikus 1 kuni 100, mis jagub nii 3-ga kui ka 5-ga.
9. Kasuta continue-i, et trükida arvud 1 kuni 20, jättes vahele kõik arvud, mis jaguvad 3-ga.
10. Kirjuta programm, mis küsib kasutajalt parooli. Anna kasutajale kolm katset for tsükliga ja katkesta break-iga, kui parool on õige.
*/

// Harjutus 1
/*
int arv = 1;
while (arv <= 10)
{
    Console.WriteLine(arv);
    arv++;
}

// Harjutus 2

for (int arv = 10; arv >= 1; arv--)
{
    Console.WriteLine(arv);
}

// Harjutus 3

int summa = 0;

for (int arv = 1; arv <= 50; arv++)
{
    if (arv % 2 == 0)
    {
        summa += arv;
    }
}

Console.WriteLine ("Paarisarvude summa: " + summa);

// Harjutus 4

string[] lemmiklaulud = { "Pulmad ja matused", "Insener Garini Hüperboloid", "Tere perestroika", "1905", "Isa tuli koju" };

foreach (string laul in lemmiklaulud)
{
    Console.WriteLine(laul);
}

// Harjutus 5

using System.Linq;

List<int> arvud = new List<int> { 5, 10, 15, 20, 25 };
int summa = 0;
int suurim = arvud[0];

foreach (int arv in arvud)
{
    summa += arv;

    if (arv > suurim)
    {
        suurim = arv;
    }
}

Console.WriteLine("Arvude summa: " + summa);
Console.WriteLine("Suurim arv: " + suurim);

// Harjutus 6

int arv = 1;
int arvudeSumma = 0;

//Console.Write("Sisesta arv: ");

while (arv != 0)
{
    Console.Write("Sisesta arv: ");
    arv = Convert.ToInt32(Console.ReadLine());
    arvudeSumma += arv;
}

Console.WriteLine("Sisestatud arvude summa: " + arvudeSumma);
*/
// Harjutus 7

// Harjutus 8

// Harjutus 9

// Harjutus 10
