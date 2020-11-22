using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class Grafika
    {
        // TODO: aktuális csatatér kirajzolása
        // TODO: 1-1 sor a játékosoknak, 1 sor az időjárásnak
        const int szelesseg = 11;
        const int magassag = 6;
        const int kezbenLevoLapokY = 46;
        const int idojarasLapokX = 82;
        const int idojarasLapokY = 20;

        private ConsoleColor lapSzin;

        private Random r = new Random();
        int ertek { get; set; }
        string tipus { get; set; }

        public Grafika(Lap lap, bool kivalasztva)
        {
            lapSzin = (kivalasztva) ? ConsoleColor.Yellow : ConsoleColor.White ;
            this.tipus = lap.Tipus.ToString();
            if (lap is MezonyLap)
                this.ertek = ((MezonyLap)lap).AktualisErtek;
            else
                this.ertek = 0;
        }

        public static void CsatamezotKirajzol(Csatamezo csatamezo, Jatekos j1, Jatekos j2)
        {
            VonalatRajzol(0, ConsoleColor.DarkCyan);
            SortKirajzol(1, csatamezo.J1Lapjai);
            Console.SetCursorPosition(66, 2);
            Console.Write($"{j1.Nev.ToUpper()}");
            Console.SetCursorPosition(66, 3);
            Console.Write($"Pontok:{csatamezo.Jatekos1Pontjai}");
            Console.SetCursorPosition(66, 4);
            Console.Write($"Életek: {j1.EletekSzama}");

            VonalatRajzol(7, ConsoleColor.DarkCyan);
            SortKirajzol(8, csatamezo.J2Lapjai);
            Console.SetCursorPosition(66, 9);
            Console.Write($"{j2.Nev.ToUpper()}");
            Console.SetCursorPosition(66, 10);
            Console.Write($"Pontok:{csatamezo.Jatekos2Pontjai}");
            Console.SetCursorPosition(66, 11);
            Console.Write($"Életek: {j2.EletekSzama}");

            VonalatRajzol(14, ConsoleColor.DarkCyan);
            SortKirajzol(15, csatamezo.IdojarasLapok);
            Console.SetCursorPosition(66, 18);
            Console.Write("IDŐJÁRÁS");
            VonalatRajzol(21, ConsoleColor.DarkCyan);
        }

        public static void KezbenLevoLapokatKirajzol(Jatekos jatekos, int kivalasztottLapSzama)
        {
            int y = 25;
            //SortKirajzol(25, jatekos.KezbenLevoLapok);
            for (int i = 0; i < jatekos.KezbenLevoLapok.Length; i++)
            {
                if (jatekos.KezbenLevoLapok[i] == null)
                {
                    LapHelyetKirajzol((i * (szelesseg + 2) + 1), y);
                }
                else
                {
                    LapotKirajzol((i * (szelesseg + 2) + 1), y, new Grafika(jatekos.KezbenLevoLapok[i], (i == kivalasztottLapSzama)));
                }
            }
        }

        public static void SortKirajzol(int y, Lap[] lapok)
        {
            for (int i = 0; i < lapok.Length; i++)
            {
                if (lapok[i] == null)
                {
                    LapHelyetKirajzol((i * (szelesseg + 2) + 1), y);
                }
                else
                {
                    LapotKirajzol((i * (szelesseg + 2) + 1), y, new Grafika(lapok[i], false));
                }
            }
        }

        private static void VonalatRajzol(int y, ConsoleColor szin)
        {
            Console.SetCursorPosition(0, y);
            Console.ForegroundColor = szin;
            Console.Write("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LapotKirajzol(int x, int y, Grafika lapGrafika)
        {
            Console.BackgroundColor = lapGrafika.lapSzin;
            for (int i = 0; i < magassag; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < szelesseg; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + szelesseg, y + i);
            }

            // Card stats
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x + 1, y);
            Console.Write((lapGrafika.ertek > 0) ? lapGrafika.ertek.ToString() : "");
            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write(lapGrafika.tipus);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, 0);
        }

        public static void LapHelyetKirajzol(int x, int y)
        {
            for (int i = 0; i < magassag; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < szelesseg; j++)
                {
                    Console.Write(".");
                }
                Console.SetCursorPosition(x + szelesseg, y + i);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, 0);
        }

        #region Teszt
        public static void MezonyLapokatKirajzolTeszt()
        {
            VonalatRajzol(0, ConsoleColor.DarkCyan);


            int y = 1;
            // 6 sort fogunk kirajzolni (játékosonként 3-3)
            for (int i = 0; i < 6; i++)
            {
                // Egy sor mezőny lap
                for (int j = 0; j < 5; j++)
                {
                    LapotKirajzol((j * (szelesseg + 2) + 1), y, new Grafika(new MezonyLap(LapTipus.Gyalogos, 9), false));
                }
                VonalatRajzol(y + magassag, (i < 2) ? ConsoleColor.DarkGreen : ConsoleColor.DarkCyan);

                y += (i == 2) ? magassag + 2 : magassag + 1;
            }

            // Kézben lévő lapok
            KezbenLevoLapokatKirajzolTeszt();
        }

        public static void LapokHelyetKirajzolTeszt()
        {
            VonalatRajzol(0, ConsoleColor.DarkCyan);

            int y = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    LapHelyetKirajzol((j * (szelesseg + 2) + 1), y);
                }

                VonalatRajzol(y + magassag, (i < 2) ? ConsoleColor.DarkGreen : ConsoleColor.DarkCyan);
                y += (i == 2) ? magassag + 2 : magassag + 1;
            }

            // Kézben lévő lapok
            KezbenLevoLapokatKirajzolTeszt();
        }

        private static int KezbenLevoLapokatKirajzolTeszt()
        {
            int y = kezbenLevoLapokY;
            for (int j = 0; j < 5; j++)
            {
                LapotKirajzol((j * (szelesseg + 2) + 1), y, new Grafika(new MezonyLap(LapTipus.Harcigep, 9), false));
            }

            return y;
        }

        #endregion
    }
}
