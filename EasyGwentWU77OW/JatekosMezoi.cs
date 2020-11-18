using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class JatekosMezoi
    {
        MezonyLap[] GyalogosLapok = new MezonyLap[5];
        MezonyLap[] TavolsagiLapok = new MezonyLap[5];
        MezonyLap[] HarcigepLapok = new MezonyLap[5];

        public int OsszErtek()
        {
            return GyalogosLapokOsszErteke() + TavolsagiLapokOsszErteke() + HarcigepLapokOsszErteke();
        }

        // Megjelenítés miatt készült külön függvény minden típus össz értékéhez
        public int GyalogosLapokOsszErteke()
        {
            int sum = 0;
            for (int i = 0; i < GyalogosLapok.Length; i++)
            {
                if (GyalogosLapok[i] != null)
                    sum += GyalogosLapok[i].AktualisErtek;
            }

            return sum;
        }

        public int TavolsagiLapokOsszErteke()
        {
            int sum = 0;
            for (int i = 0; i < TavolsagiLapok.Length; i++)
            {
                if (TavolsagiLapok[i] != null)
                    sum += TavolsagiLapok[i].AktualisErtek;
            }

            return sum;
        }

        public int HarcigepLapokOsszErteke()
        {
            int sum = 0;
            for (int i = 0; i < HarcigepLapok.Length; i++)
            {
                if (HarcigepLapok[i] != null)
                    sum += HarcigepLapok[i].AktualisErtek;
            }

            return sum;
        }
    }
}
