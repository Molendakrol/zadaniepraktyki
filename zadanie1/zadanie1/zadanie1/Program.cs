using System;
using System.IO;
using System.Text;

class Litera
{
    public static void Main()
    {
        string sciezka = @"c:/test/test_jak_mol.txt";
        string zawartosc = File.ReadAllText(sciezka);
        int liczba = zawartosc.Count(c => c == 'a');
        Console.WriteLine($"Litera 'a' wystepuje {liczba} razy.");
    }
}