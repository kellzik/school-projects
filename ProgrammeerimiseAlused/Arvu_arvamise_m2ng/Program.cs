namespace Arvu_arvamise_m2ng;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            int arvutiArv = new Random().Next(1, 11);
            // Console.WriteLine("Arvuti valitud arv: " + arvutiArv); // See rida on ainult testimiseks, et näha arvuti valitud arvu.
            Console.WriteLine("Arva ära arvuti valitud arv (1-10): ");
            int kasutajaArv = Convert.ToInt32(Console.ReadLine());

            if (kasutajaArv > arvutiArv)
            {
                Console.WriteLine("Vale! Sinu pakutav arv on suurem kui arvuti valitud arv. Mäng algab uuesti.");
            }
            else if (kasutajaArv < arvutiArv)
            {
                Console.WriteLine("Vale! Sinu pakutav arv on väiksem kui arvuti valitud arv. Mäng algab uuesti.");
            }
            else
            {
                // Console.WriteLine($"Õige! Arvasid ära!");
                break;
            }
        }
    }
}

