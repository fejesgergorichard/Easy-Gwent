using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class Csatamezo
    {
        public JatekosMezoi J1Mezoi { get; private set; }
        public JatekosMezoi J2Mezoi { get; private set; }

        IdojarasLap[] IdojarasLapok = new IdojarasLap[5];


        public void IdojarasLapokatAktival()
        {
            for (int i = 0; i < IdojarasLapok.Length; i++)
            {
                IdojarasLapok[i].Aktival();
            }
        }

    }
}
