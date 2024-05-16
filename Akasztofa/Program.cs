namespace Akasztofa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jatek = new AJatek();
            jatek.BeSzavak("markak.txt");
            jatek.HelyesTalalat += (szo) => Console.WriteLine("Helyes! Jelenlegi szó: " + szo);
            jatek.HelytelenTalalat += (maradekProba) => Console.WriteLine("Nem jó! Maradék próbálkozások: " + maradekProba);
            jatek.JatekVege += (szo, nyert) =>
            {
                if(nyert)
                {
                    Console.WriteLine("Gratulálok, kitaláltad a helyes szót: " + szo);
                }
                else
                {
                    Console.WriteLine("Elfogytak a próbálkozások! A helyes szó: " + szo);
                }
            };
            while (true)
            {
                jatek.Jatek();
                Console.WriteLine("Szeretnél megint játszani? (I/N)");
                if (Console.ReadLine().ToUpper() != "I")
                {
                    break;
                }
            }
        }
    }
}