using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class MezonyLap : Lap
    {
        bool gyengitett = false;
        public int EredetiErtek { get; }        // Az eredeti érték csak olvasható
        
        public int AktualisErtek
        {
            get
            {
                if (gyengitett)
                    return 1;
                else
                    return EredetiErtek;
            }
        }

        public MezonyLap(LapTipus tipus, int ertek) : base(tipus)
        {
            EredetiErtek = ertek;
        }


    }
}
