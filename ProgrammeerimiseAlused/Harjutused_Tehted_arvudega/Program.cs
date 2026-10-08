/*
Harjutused:
1. Kirjuta programm, mis arvutab ruudu pindala
2. Kirjuta programm, mis arvutab ristküliku pindala
3. Kirjuta programm, mis küsib kasutajalt ringi raadiust ja arvutab ringi pindala (Math.Pi annab pii väärtuse)
*/

// Harjutus 1

Console.Write("Sisesta ruudu külje pikkus (cm): ");
double kylg = Convert.ToDouble(Console.ReadLine());

double ruuduPindala = kylg * kylg;
Console.WriteLine("Ruudu pindala on " + ruuduPindala + " cm².");

// Harjutus 2

Console.Write("Sisesta ristküliku esimese külje pikkus (cm): ");
double kylg1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Sisesta ristküliku teise külje pikkus (cm): ");
double kylg2 = Convert.ToDouble(Console.ReadLine());

double ristkylikuPindala = kylg1 * kylg2;
Console.WriteLine("Ristküliku pindala on " + ristkylikuPindala + " cm².");

// Harjutus 3

Console.Write("Sisesta ringi raadius (cm): ");
double raadius = Convert.ToDouble(Console.ReadLine());

double ringiPindala = Math.PI * raadius * raadius;
Console.WriteLine("Ringi pindala on " + ringiPindala + " cm².");