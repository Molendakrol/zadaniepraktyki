using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string[] imiona = { "Ania", "Kasia", "Basia", "Zosia" };
        string[] nazwiska = { "Kowalska", "Nowak" };
        string dzisiaj = DateTime.Now.ToString("yyyy_MM_dd");

        Random rand = new Random();
        int liczbarekordow = 100;
        string sciezka = @$"c:/test/users-{dzisiaj}.csv";
        
        using (var writer = new StreamWriter(sciezka, false, Encoding.UTF8))
        {
            writer.WriteLine("Lp, Imię, Nazwisko, RokUrodzenia");

            for (int i = 1; i <= liczbarekordow; i++)
            {
                string imie = imiona[rand.Next(imiona.Length)];
                int rokUrodzenia = rand.Next(1990, 2001);
                string nazwisko = nazwiska[rand.Next(nazwiska.Length)];

                writer.WriteLine($"{i}, {imie}, {nazwisko}, {rokUrodzenia}");
            }
        }
    }
}