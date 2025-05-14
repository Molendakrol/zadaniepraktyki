using System;
using System.IO;
using System.Text;

class zamiana
{
    public static void Main()
    {
        string sciezka = @"c:/test/jobpraca.txt";
        string nowa_sciezka = @"c:/test/jobpraca_changed.txt";
        string tekst = File.ReadAllText(sciezka);
        string zmiana = tekst.Replace("praca", "job");
        File.WriteAllText(sciezka, zmiana);
        File.Move(sciezka, nowa_sciezka);
    }
}