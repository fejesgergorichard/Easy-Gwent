using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class MezonyLap : Lap
    {
        public int EredetiErtek { get; }        // Az eredeti érték csak olvasható
        public int AktualisErtek { get; set; }  // Az aktuális értéken lehet változtatni

        public MezonyLap(LapTipus tipus, int ertek) : base(tipus)
        {
            EredetiErtek = ertek;
        }

        public void Aktival()
        {

        }

        public void Gyengit()
        {

        }

        public void Visszaallit()
        {

        }
    }
}
