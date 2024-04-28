using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akasztofa
{
    public class Szo
    {
        public string Ertek { get; private set; }
        public char[] Tippek { get; private set; }

        public Szo(string ertek)
        {
            Ertek = ertek.ToUpper();
            Tippek = new string('_', Ertek.Length).ToCharArray();
        }

        public bool Tipp(char betu)
        {
            bool vanHelyes = false;
            for(int i = 0; i < Ertek.Length; i++)
            {
                if (Ertek[i] == betu)
                {
                    Tippek[i] = betu;
                    vanHelyes = true;
                }
            }
            return vanHelyes;
        }

        public bool Kesz()
        {
            return !Tippek.Contains('_');
        }

        public void FelfedBetu()
        {
            List<int> rejtettIndex = new List<int>();
            for (int i = 0; i < Ertek.Length; i++)
            {
                if (Tippek[i] == '_')
                {
                    rejtettIndex.Add(i);
                }
            }
            if (rejtettIndex.Count > 0)
            {
                int felfedIndex = new Random().Next(rejtettIndex.Count);
                Tippek[rejtettIndex[felfedIndex]] = Ertek[rejtettIndex[felfedIndex]];
            }

        }

        public override string ToString()
        {
            return new string(Tippek);
        }
    }
}
