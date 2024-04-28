using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akasztofa
{
    public delegate void TippDelegate(string szo);
    public delegate void RosszTippDelegate(int maradekProba);
    public delegate void JatekVegeDelegate(string szo, bool nyert);
    public class AJatek
    {
        private Szo jelenlegiSzo;
        private int maxProba = 3;
        public event TippDelegate HelyesTalalat;
        public event RosszTippDelegate HelytelenTalalat;
        public event JatekVegeDelegate JatekVege;

        public AJatek()
        {
            UjraJatek();
        }

        private void UjraJatek()
        {
            string[] Szotar = { "FERRARI", "MERCEDES", "FORD", "OPEL", "BMW" };
            Random rnd = new Random();
            jelenlegiSzo = new Szo(Szotar[rnd.Next(Szotar.Length)]);
        }

        public void Jatek()
        {
            Console.WriteLine("Találd ki a helyes autó márkát: " + jelenlegiSzo);
            int proba = 0;
            while (proba < maxProba && !jelenlegiSzo.Kesz())
            {
                Console.WriteLine("Írd be a tipped (? a segítségért): ");
                char tipp = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (tipp == '?')
                {
                    jelenlegiSzo.FelfedBetu();
                    HelyesTalalat?.Invoke(jelenlegiSzo.ToString());
                }
                else
                {
                    if (jelenlegiSzo.Tipp(tipp))
                    {
                        HelyesTalalat?.Invoke(jelenlegiSzo.ToString());
                    }
                    else
                    {
                        proba++;
                        HelytelenTalalat?.Invoke(maxProba - proba);
                    }
                }

                Console.WriteLine("A jelenlegi szó: " + jelenlegiSzo);
            }

            bool nyert = jelenlegiSzo.Kesz();
            JatekVege?.Invoke(jelenlegiSzo.Ertek, nyert);

            UjraJatek();
        }
    }
}
