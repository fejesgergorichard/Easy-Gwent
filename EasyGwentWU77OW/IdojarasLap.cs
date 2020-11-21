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
            for (int i = 0; i < csatamezo.J1Mezoi.LerakottLapok.Length; i++)
            {
                // Játékos 1 lerakott lapjait gyengíti
                if (csatamezo.J1Mezoi.LerakottLapok[i] != null && csatamezo.J1Mezoi.LerakottLapok[i].Tipus == gyengitettTipus)
                {
                    csatamezo.J1Mezoi.LerakottLapok[i].Gyengitett = true;
                }

                // Játékos 2 lerakott lapjait gyengítí
                if (csatamezo.J2Mezoi.LerakottLapok[i] != null && csatamezo.J2Mezoi.LerakottLapok[i].Tipus == gyengitettTipus)
                {
                    csatamezo.J2Mezoi.LerakottLapok[i].Gyengitett = true;
                }
            }
        }

        public void Visszaallit(Csatamezo csatamezo)
        {
            // Értékek visszaállításra alapra
            for (int i = 0; i < 5; i++)
            {
                // Játékos 1 lerakott lapjai
                if (csatamezo.J1Mezoi.LerakottLapok[i] != null)
                {
                    csatamezo.J1Mezoi.LerakottLapok[i].Gyengitett = false;
                }

                // Játékos 2 lerakott lapjai
                if (csatamezo.J2Mezoi.LerakottLapok[i] != null)
                {
                    csatamezo.J2Mezoi.LerakottLapok[i].Gyengitett = false;
                }
            }

            // Minden időjárás lap eltüntetése
            for (int i = 0; i < csatamezo.IdojarasLapok.Length; i++)
            {
                csatamezo.IdojarasLapok[i] = null;
            }
        }
    }

}
