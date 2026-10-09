/*
Harjutused:
1. Kirjuta programm, mis kontrollib, kas number on positiivne (> 0), negatiivne (< 0) või null. Küsi number kasutajalt.
2. Kirjuta programm, mis kontrollib, kas kasutaja on sisselogitud JA kas tal on admini õigused. Kasuta kahte booli muutujat.
3. Kirjuta programm, mis võrdleb kahe õpilase hindeid. Kellel on kõrgem keskmine? Kas mõlemal on miinimumhinne 3?
*/

// Harjutus 1

Console.Write("Sisesta number: ");
int number = Convert.ToInt32(Console.ReadLine());

if (number > 0)
{
    Console.WriteLine("Number on positiivne.");
}
else if (number < 0)
{
    Console.WriteLine("Number on negatiivne.");
}
else
{
    Console.WriteLine("Number on null.");
}

// Harjutus 2

bool onSisselogitud = true;
bool onAdmin = false;

if (onSisselogitud && onAdmin)
{
    Console.WriteLine("Kasutaja on sisselogitud ja tal on admini õigused.");
}
else if (onSisselogitud && !onAdmin)
{
    Console.WriteLine("Kasutaja on sisselogitud, kuid tal ei ole admini õigusi.");
}
else
{
    Console.WriteLine(" Kasutaja ei ole sisselogitud ega oma admini õigusi.");
}

// Harjutus 3

int[] opilane1Hinded = { 4, 5, 5, 4 };
int[] opilane2Hinded = { 5, 4, 4, 5 };

double opilane1Keskmine = opilane1Hinded.Average();
double opilane2Keskmine = opilane2Hinded.Average();

if (opilane1Keskmine > opilane2Keskmine)
{
    Console.WriteLine("Esimesel õpilasel on kõrgem keskmine hinne.");
}
else if (opilane2Keskmine > opilane1Keskmine)
{
    Console.WriteLine("Teisel õpilasel on kõrgem keskmine hinne.");
}
else
{
    Console.WriteLine("Mõlemal õpilasel on sama keskmine hinne.");
}

bool opilane1MinHinne3 = opilane1Hinded.Contains(3);
bool opilane2MinHinne3 = opilane2Hinded.Contains(3);

if (opilane1MinHinne3 && opilane2MinHinne3)
{
    Console.WriteLine("Mõlemal õpilasel on miinimumhinne 3.");
}
else if (opilane1MinHinne3)
{
    Console.WriteLine("Ainult esimesel õpilasel on miinimumhinne 3.");
}
else if (opilane2MinHinne3)
{
    Console.WriteLine("Ainult teisel õpilasel on miinimumhinne 3.");
}
else
{
    Console.WriteLine("Kummalgi õpilasel ei ole miinimumhinnet 3.");
}