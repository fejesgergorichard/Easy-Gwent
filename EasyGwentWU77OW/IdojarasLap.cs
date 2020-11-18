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

        /// <summary>
        /// Aktiválja a lap hatását a mezőn elhelyezett lapokra.
        /// </summary>
        public void Aktival()
        {
            if (this.Tipus == LapTipus.Eso)
            {

            }
            else if (this.Tipus == LapTipus.Kod)
            {

            }
            else if (this.Tipus == LapTipus.Napsutes)
            {
                Visszaallit();
            }

        }

        /// <summary>
        /// Gyengíti az adott típusú kártyákat (értékük 1 lesz).
        /// </summary>
        /// <param name="gyengitettTipus">A gyengített kártya típus.</param>
        public void Gyengit(LapTipus gyengitettTipus)
        {

        }

        public void Visszaallit()
        {

        }
    }

}
