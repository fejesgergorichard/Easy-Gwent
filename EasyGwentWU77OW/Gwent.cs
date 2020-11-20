using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EasyGwentWU77OW
{
    public class Gwent
    {
        Random r = new Random();
        public Jatekos Jatekos1 { get; private set; }
        public Jatekos Jatekos2 { get; private set; }
        Lap[] pakli = new Lap[30];
        int hatralevoKorokSzama = 3;        // 3...0
        bool jatekFolyamatban = true;


        public void Start()
        {
            // Játékos 1 létrehozása
            string nev;
            do
            {
                Console.Write("Játékos 1 neve: ");
                nev = Console.ReadLine();
            }
            while (nev == null || nev == "");
            Jatekos1 = new Jatekos(nev);

            // Játékos 2 létrehozása
            nev = null;
            do
            {
                Console.Write("Játékos 2 neve: ");
                nev = Console.ReadLine();
            }
            while (nev == null || nev == "");
            Jatekos2 = new Jatekos(nev);

            // Pakli generálás
            Console.WriteLine();
            Console.Write("Pakli létrehozása és keverése");
            PakliGeneralas();
            Kever();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }

            // Lapok kiosztása a játékosoknak
            Console.WriteLine();
            Console.Write("Lapok kiosztása a játékosoknak");
            LapokatKioszt();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }

        }

        private void PakliGeneralas()
        {
            // 9 Gyalogos
            pakli[0] = new MezonyLap(LapTipus.Gyalogos, 1);
            pakli[1] = new MezonyLap(LapTipus.Gyalogos, 2);
            pakli[2] = new MezonyLap(LapTipus.Gyalogos, 3);
            pakli[3] = new MezonyLap(LapTipus.Gyalogos, 4);
            pakli[4] = new MezonyLap(LapTipus.Gyalogos, 5);
            pakli[5] = new MezonyLap(LapTipus.Gyalogos, 6);
            pakli[6] = new MezonyLap(LapTipus.Gyalogos, 7);
            pakli[7] = new MezonyLap(LapTipus.Gyalogos, 8);
            pakli[8] = new MezonyLap(LapTipus.Gyalogos, 9);

            // 8 Távolsági
            pakli[9] = new MezonyLap(LapTipus.Tavolsagi, 2);
            pakli[10] = new MezonyLap(LapTipus.Tavolsagi, 3);
            pakli[11] = new MezonyLap(LapTipus.Tavolsagi, 4);
            pakli[12] = new MezonyLap(LapTipus.Tavolsagi, 5);
            pakli[13] = new MezonyLap(LapTipus.Tavolsagi, 6);
            pakli[14] = new MezonyLap(LapTipus.Tavolsagi, 7);
            pakli[15] = new MezonyLap(LapTipus.Tavolsagi, 8);
            pakli[16] = new MezonyLap(LapTipus.Tavolsagi, 9);

            // 8 Harcigép
            pakli[17] = new MezonyLap(LapTipus.Harcigep, 4);
            pakli[18] = new MezonyLap(LapTipus.Harcigep, 4);
            pakli[19] = new MezonyLap(LapTipus.Harcigep, 6);
            pakli[20] = new MezonyLap(LapTipus.Harcigep, 6);
            pakli[21] = new MezonyLap(LapTipus.Harcigep, 8);
            pakli[22] = new MezonyLap(LapTipus.Harcigep, 8);
            pakli[23] = new MezonyLap(LapTipus.Harcigep, 9);
            pakli[24] = new MezonyLap(LapTipus.Harcigep, 9);

            // 5 Időjárás
            pakli[25] = new IdojarasLap(LapTipus.Kod);
            pakli[26] = new IdojarasLap(LapTipus.Eso);
            pakli[27] = new IdojarasLap(LapTipus.Eso);
            pakli[28] = new IdojarasLap(LapTipus.Fagy);
            pakli[29] = new IdojarasLap(LapTipus.Napsutes);

        }

        private void Kever()
        {
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < pakli.Length; i++)
                {
                    Csere(i, r.Next(i, pakli.Length), pakli);
                }
            }
        }

        private void Csere(int i, int j, Lap[] pakli)
        {
            Lap tmp = pakli[i];
            pakli[i] = pakli[j];
            pakli[j] = tmp;
        }

        private void LapokatKioszt()
        {
            for (int i = 0; i < 15; i++)
            {
                Jatekos1.OsztottLapok[i] = pakli[i];
                Jatekos2.OsztottLapok[i] = pakli[i + 15];
            }
        }
    }
}
