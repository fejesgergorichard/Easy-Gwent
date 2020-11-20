using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    public class MezonyLap : Lap
    {
        public bool Gyengitett { get; set; }
        public int EredetiErtek { get; }        // Az eredeti érték csak olvasható
        
        public int AktualisErtek
        {
            get
            {
                if (Gyengitett)
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
