using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    public class JatekosMezoi
    {
        public MezonyLap[] LerakottLapok = new MezonyLap[5];

        // Megjelenítés miatt készült külön függvény minden típus össz értékéhez
        public int OsszErtek()
        {
            int sum = 0;
            for (int i = 0; i < LerakottLapok.Length; i++)
            {
                if (LerakottLapok[i] != null)
                    sum += LerakottLapok[i].AktualisErtek;
            }

            return sum;
        }
    }
}
