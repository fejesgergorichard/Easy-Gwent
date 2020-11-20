using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    // Egy kártya az alábbi tipusok valamelyike lehet.
    public enum LapTipus
    {
        Gyalogos,
        Tavolsagi,
        Harcigep,
        Kod,
        Eso,
        Fagy,
        Napsutes
    }

    public class Lap
    {
        private LapTipus tipus;

        public LapTipus Tipus { get { return tipus; } }

        public Lap(LapTipus tipus)
        {
            this.tipus = tipus;
        }
    }
}
