/*
Harjutused:
1. Loo massiiv viie lemmikfilmi nimega. Kuva kõik filmid ekraanile nummerdatult, kasutades iga indeksit eraldi (1. Film, 2. Film, ...).
2. Loo loend sõpradest. Lisa kolm sõpra, seejärel eemalda üks ja kuva lõplik nimekiri koos arvuga.
3. Loo massiiv viie klassikaaslase nimega. Kuva esimene, kolmas ja viimane nimi. Seejärel muuda teine nimi uue nimega ja kuva muudetud massiiv.
*/

// Harjutus 1

string[] lemmikFilmid = { "The Zookeeper's Wife", "Jerry & Marge Go Large", "Parasite", "Idiocracy", "Home Alone" };
Console.WriteLine("1. " + lemmikFilmid[0]);
Console.WriteLine("2. " + lemmikFilmid[1]);
Console.WriteLine("3. " + lemmikFilmid[2]);
Console.WriteLine("4. " + lemmikFilmid[3]);
Console.WriteLine("5. " + lemmikFilmid[4]);

// Harjutus 2

List<string> sobrad = new List<string> { "Agnes", "Piret", "Tanel" };
sobrad.RemoveAt(1); // Eemaldab teise sõbra nimekirjast (Piret) = sobrad.Remove("Piret");
Console.WriteLine("Sõbrad: " + sobrad[0] + ", " + sobrad[1]); // Pärast Pireti nimekirjast eemaldamist tehakse indeksid ümber, seega on Tanel nüüd indeksiga 1
Console.WriteLine("Sõprade arv: " + sobrad.Count);

// Harjutus 3

string[] klassikaaslased = { "Martin", "Riho", "Katrin", "Marju", "Karl" };
Console.WriteLine(klassikaaslased[0] + ", " + klassikaaslased[2] + ", " + klassikaaslased[4]);
klassikaaslased[1] = "Rico"; // Muudab Riho nimeks Rico
Console.WriteLine("Muudetud massiiv: " + klassikaaslased[0] + ", " + klassikaaslased[1] + ", " + klassikaaslased[2] + ", " + klassikaaslased[3] + ", " + klassikaaslased[4]);

// Kasutades string.Join meetodit: 
// Console.WriteLine("Muudetud massiiv: " + string.Join(", ", klassikaaslased));