﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class Jatekos
    {
        Random r = new Random();
        Lap[] OsztottLapok { get; set; }
        int osztottLapokSzama;  // Ez trackeli hogy hány lap van még
        Lap[] KezbenLevoLapok { get; set; }

        public void Felhuz()
        {
            for (int i = 0; i < KezbenLevoLapok.Length; i++)
            {
                if (KezbenLevoLapok[i] == null)
                {
                    int j = r.Next(OsztottLapok.Length);    // TODO: Lehet jobb ha nem random
                    KezbenLevoLapok[i] = OsztottLapok[j];
                }
            }
        }

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
    }
}
