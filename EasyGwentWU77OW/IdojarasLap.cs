using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class IdojarasLap : Lap
    {
        LapTipus gyengitettTipus;

        public IdojarasLap(LapTipus tipus, LapTipus gyengitettTipus) : base(tipus)
        {
            this.gyengitettTipus = gyengitettTipus;
        }
    }

}
