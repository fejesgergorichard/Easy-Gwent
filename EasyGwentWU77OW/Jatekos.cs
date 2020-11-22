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
            OsztottLapok = new Lap[15];
            KezbenLevoLapok = new Lap[5];
        }

        public void Felhuz()
        {
            while (KezbenLevoLapokSzama() != 5)
            {
                for (int i = 0; i < KezbenLevoLapok.Length; i++)
                {

                }
            }
        }

        //public void Felhuz()
        //{
        //    for (int i = 0; i < KezbenLevoLapok.Length; i++)
        //    {
        //        if (KezbenLevoLapok[i] == null)
        //        {
        //            int j = r.Next(OsztottLapok.Length);    // TODO: Lehet jobb ha nem random
        //            KezbenLevoLapok[i] = OsztottLapok[j];
        //        }
        //    }
        //}

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
