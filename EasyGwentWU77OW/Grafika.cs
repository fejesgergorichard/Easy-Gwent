using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class Grafika
    {
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
            lapSzin = (kivalasztva) ? ConsoleColor.Yellow : ConsoleColor.White;
            this.tipus = lap.Tipus.ToString();
            if (lap is MezonyLap)
            {
                this.ertek = ((MezonyLap)lap).AktualisErtek;
                if (((MezonyLap)lap).Gyengitett)
                {
                    lapSzin = ConsoleColor.DarkGray;
                }
            }
            else
                this.ertek = 0;
        }

        public static void Szabalyok()
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("- SZABÁLYZAT -\n");
            Console.WriteLine("A paklit 25 lap alkotja:\n" +
                "\t- 9 Gyalogos egység\n\t- 8 Távolsági egység\n\t- 8 Harcigép egység\n" +
                "\t- 5 időjárás lap\n\t\t- Eső(2x): A harcigépeket gyengíti\n\t\t- Köd: A távolsági egységeket gyengíti\n\t\t- Fagy: A gyalogos egységeket gyengíti" +
                "\n\t\t- Napsütés: Eltüntet minden időjárás lapot és azok hatását megszünteti\n" +
                "\tGyengítés alatt azt értjük, hogy a gyengített típusok harci értékét 1-re állítja.\n\tEzeket a lapokat szürkével jelöljük:\n");
            MezonyLap l = new MezonyLap(LapTipus.Gyalogos, 9);
            l.Gyengitett = true;
            LapotKirajzol(9, 14, new Grafika(l, false));
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("A játék kezdetén minden játékos 15-15 lapot kap a pakliból.\nEbből 5 lapot kézbe vesznek és minden lapról eldönthetik, hogy lerakják-e vagy sem." +
                "\nAmikor mindkét játékos lerakta a lapjait, a kör végén azok értékét összegezzük.\nAz nyeri a kört, akinek több pontja volt a lerakott lapokból." +
                "\nA kör végén a vesztes játékos egy életet veszít." +
                "\n\nA játék addig tart, ameddig valamelyik játékosnak el nem fogy az élete.");
        }

        /// <summary>
        /// Kirajzolja a csatamezőt és az egyes játékosok statisztikáit.
        /// </summary>
        /// <param name="csatamezo">Csatamező</param>
        /// <param name="j1">Játékos 1</param>
        /// <param name="j2">Játékos 2</param>
        public static void CsatamezotKirajzol(Csatamezo csatamezo, Jatekos j1, Jatekos j2)
        {
            VonalatRajzol(0, ConsoleColor.DarkCyan);
            SortKirajzol(1, csatamezo.J1Lapjai);
            Console.SetCursorPosition(66, 2);
            Console.Write($"{j1.Nev.ToUpper()}");
            Console.SetCursorPosition(66, 3);
            Console.Write($"Pontok: {csatamezo.Jatekos1Pontjai}");
            Console.SetCursorPosition(66, 4);
            Console.Write($"Életek: {j1.EletekSzama}");

            VonalatRajzol(7, ConsoleColor.DarkCyan);
            SortKirajzol(8, csatamezo.J2Lapjai);
            Console.SetCursorPosition(66, 9);
            Console.Write($"{j2.Nev.ToUpper()}");
            Console.SetCursorPosition(66, 10);
            Console.Write($"Pontok: {csatamezo.Jatekos2Pontjai}");
            Console.SetCursorPosition(66, 11);
            Console.Write($"Életek: {j2.EletekSzama}");

            VonalatRajzol(15, ConsoleColor.DarkCyan);
            SortKirajzol(16, csatamezo.IdojarasLapok);
            Console.SetCursorPosition(66, 19);
            Console.Write("IDŐJÁRÁS");
            VonalatRajzol(22, ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Kirajzolja az adott játékos kezében lévő lapokat, beszínezve az épp kiválasztott lapot.
        /// </summary>
        /// <param name="jatekos">Játékos akinek a lapjait meg akarjuk jeleníteni.</param>
        /// <param name="kivalasztottLapSzama">A kiválasztott lap indexe.</param>
        public static void KezbenLevoLapokatKirajzol(Jatekos jatekos, int kivalasztottLapSzama)
        {
            int y = 25;
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
            Console.SetCursorPosition(66, 28);
            Console.Write($"{jatekos.Nev} Lapjai");
        }

        /// <summary>
        /// Kirajzol egy Lap[] tömböt az adott y koordinátára.
        /// </summary>
        /// <param name="y">y koordináta.</param>
        /// <param name="lapok">A kirajzolandó tömb.</param>
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

        /// <summary>
        /// Rajzol egy vízszintes elválasztó vonalat az adott y koordinátára, szin színnel.
        /// </summary>
        /// <param name="y">Vonal y koordinátája.</param>
        /// <param name="szin">Vonal színe.</param>
        private static void VonalatRajzol(int y, ConsoleColor szin)
        {
            Console.SetCursorPosition(0, y);
            Console.ForegroundColor = szin;
            Console.Write("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Kirajzol egy lapot a megadott x,y koordinátákra.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="lapGrafika">Megjelenítéshez használt lapgrafika.</param>
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

            // Kártya adatai
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = lapGrafika.lapSzin;
            Console.SetCursorPosition(x + 1, y);
            Console.Write((lapGrafika.ertek > 0) ? lapGrafika.ertek.ToString() : "");
            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write(lapGrafika.tipus);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Kirajzolja egy lap placeholderét a megadott x,y koordinátákra.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
