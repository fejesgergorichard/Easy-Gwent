using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    // Egy kártya az alábbi tipusok valamelyike lehet.
    enum LapTipus
    {
        Gyalogos,
        Tavolsagi,
        Harcigep,
        Kod,
        Eso,
        Napsutes
    }

    class Lap
    {
        LapTipus tipus;
        public LapTipus Tipus { get { return tipus; } }
        int szelesseg = 11;     // TODO: rajzoló osztály, ahol a grafikus adatokat tároljuk
        int magassag = 6;

        public Lap(LapTipus tipus)
        {
            this.tipus = tipus;
        }
    }
}
