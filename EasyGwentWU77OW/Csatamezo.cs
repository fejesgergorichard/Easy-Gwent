using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    public class Csatamezo
    {
        public MezonyLap[] J1Lapjai { get; set; } = new MezonyLap[5];
        public MezonyLap[] J2Lapjai { get; set; } = new MezonyLap[5];

        public IdojarasLap[] IdojarasLapok = new IdojarasLap[5];

        public int Jatekos1Pontjai { get { return OsszErtek(J1Lapjai); } }
        public int Jatekos2Pontjai { get { return OsszErtek(J2Lapjai); } }

        /// <summary>
        /// Eltávolítja az összes lapot a csatatérről.
        /// </summary>
        public void Tisztit()
        {
            J1Lapjai = new MezonyLap[5];
            J2Lapjai = new MezonyLap[5];
            IdojarasLapok = new IdojarasLap[5];
        }

        /// <summary>
        /// Megszámolja a csatatéren az átadott típusú lapok számát.
        /// </summary>
        /// <param name="tipus">A megszámlálandó típus.</param>
        /// <returns></returns>
        public int ElhelyezettLapokTipusbol(LapTipus tipus)
        {
            int sum = 0;
            for (int i = 0; i < J1Lapjai.Length; i++)
            {
                if (J1Lapjai[i] != null && J1Lapjai[i].Tipus == tipus)
                    sum++;
                if (J2Lapjai[i] != null && J2Lapjai[i].Tipus == tipus)
                    sum++;
                if (IdojarasLapok[i] != null && IdojarasLapok[i].Tipus == tipus)
                    sum++;
            }

            return sum;
        }

        /// <summary>
        /// Kiszámolja az IdojarasLapok tömb legkisebb szabad koordinátáját.
        /// </summary>
        /// <returns></returns>
        public int SzabadIdojarasKoordinata()
        {
            int i = 0;
            while (i < IdojarasLapok.Length && IdojarasLapok[i] != null)
            {
                i++;
            }
            return i;
        }

        /// <summary>
        /// Aktiválja az összes időjárás lapot.
        /// </summary>
        public void IdojarasLapokatAktival()
        {
            for (int i = 0; i < IdojarasLapok.Length; i++)
            {
                if (IdojarasLapok[i] != null)
                {
                    IdojarasLapok[i].Aktival(this);
                }
            }
        }

        /// <summary>
        /// Megadja egy MezonyLap[] tömbben az összpontszámot.
        /// </summary>
        /// <param name="lapok">A vizsgálandó tömb.</param>
        /// <returns>Tömbben lévő mezőny kártyák össz értéke.</returns>
        private int OsszErtek(MezonyLap[] lapok)
        {
            int sum = 0;
            for (int i = 0; i < lapok.Length; i++)
            {
                if (lapok[i] != null)
                    sum += lapok[i].AktualisErtek;
            }

            return sum;
        }

    }
}
