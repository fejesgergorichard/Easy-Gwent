using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    public class IdojarasLap : Lap
    {
        public IdojarasLap(LapTipus tipus) : base(tipus) { }

        /// <summary>
        /// Aktiválja a lap hatását a mezőn elhelyezett lapokra.
        /// </summary>
        public void Aktival(Csatamezo csatamezo)
        {
            if (this.Tipus == LapTipus.Eso)
            {
                Gyengit(LapTipus.Harcigep, csatamezo);
            }
            else if (this.Tipus == LapTipus.Kod)
            {
                Gyengit(LapTipus.Tavolsagi, csatamezo);
            }
            else if (this.Tipus == LapTipus.Fagy)
            {
                Gyengit(LapTipus.Gyalogos, csatamezo);
            }
            else if (this.Tipus == LapTipus.Napsutes)
            {
                Visszaallit(csatamezo);
            }

        }

        /// <summary>
        /// Gyengíti az adott típusú kártyákat (értékük 1 lesz).
        /// </summary>
        /// <param name="gyengitettTipus">A gyengített kártya típus.</param>
        public void Gyengit(LapTipus gyengitettTipus, Csatamezo csatamezo)
        {
            for (int i = 0; i < 5; i++)
            {
                if (csatamezo.J1Mezoi.GyalogosLapok[i] != null && csatamezo.J1Mezoi.GyalogosLapok[i].Tipus == gyengitettTipus)
                {
                    csatamezo.J1Mezoi.GyalogosLapok[i].Gyengitett = true;
                }
                if (csatamezo.J1Mezoi.HarcigepLapok[i] != null && csatamezo.J1Mezoi.HarcigepLapok[i].Tipus == gyengitettTipus)
                {
                    csatamezo.J1Mezoi.HarcigepLapok[i].Gyengitett = true;
                }
                if (csatamezo.J1Mezoi.TavolsagiLapok[i] != null && csatamezo.J1Mezoi.TavolsagiLapok[i].Tipus == gyengitettTipus)
                {
                    csatamezo.J1Mezoi.TavolsagiLapok[i].Gyengitett = true;
                }
            }
        }

        public void Visszaallit(Csatamezo csatamezo)
        {
            for (int i = 0; i < 5; i++)
            {
                if (csatamezo.J1Mezoi.GyalogosLapok[i] != null)
                {
                    csatamezo.J1Mezoi.GyalogosLapok[i].Gyengitett = false;
                }
                if (csatamezo.J1Mezoi.HarcigepLapok[i] != null)
                {
                    csatamezo.J1Mezoi.HarcigepLapok[i].Gyengitett = false;
                }
                if (csatamezo.J1Mezoi.TavolsagiLapok[i] != null)
                {
                    csatamezo.J1Mezoi.TavolsagiLapok[i].Gyengitett = false;
                }
            }
        }
    }

}
