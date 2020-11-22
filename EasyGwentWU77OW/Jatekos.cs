using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    public class Jatekos
    {
        private Random r = new Random();
        public int EletekSzama { get; set; }
        public string Nev { get; private set; }

        public Lap[] OsztottLapok { get; set; }
        public Lap[] KezbenLevoLapok { get; set; }


        public Jatekos(string nev)
        {
            Nev = nev;
            EletekSzama = 2;
            OsztottLapok = new Lap[15];
            KezbenLevoLapok = new Lap[5];
        }


        /// <summary>
        /// Az OsztottLapokból a KezbenLevoLapok tömböt feltölti, ahol hiányzó elem van.
        /// </summary>
        public void Felhuz()
        {
            while (KezbenLevoLapokSzama() != 5 && OsztottLapokSzama() > 0)
            {
                for (int i = 0; i < KezbenLevoLapok.Length; i++)
                {
                    // Ha az indexen nincs lap, felhúzunk egyet
                    if (KezbenLevoLapok[i] == null)
                    {
                        int j = 0;
                        while (j < OsztottLapok.Length && KezbenLevoLapok[i] == null)
                        {
                            if (OsztottLapok[j] != null)
                            {
                                KezbenLevoLapok[i] = OsztottLapok[j];
                                OsztottLapok[j] = null;
                            }
                            j++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Megszámolja a KezbenLevoLapok tömbben lévő elemek számát.
        /// </summary>
        /// <returns>Kézben lévő lapok száma.</returns>
        public int KezbenLevoLapokSzama()
        {
            int db = 0;
            for (int i = 0; i < KezbenLevoLapok.Length; i++)
            {
                if (KezbenLevoLapok[i] != null)
                    db++;
            }
            return db;
        }

        /// <summary>
        /// Megszámolja hány osztott lap van a játékosnál.
        /// </summary>
        /// <returns></returns>
        public int OsztottLapokSzama()
        {
            int db = 0;
            for (int i = 0; i < OsztottLapok.Length; i++)
            {
                if (OsztottLapok[i] != null)
                    db++;
            }
            return db;
        }
    }
}
