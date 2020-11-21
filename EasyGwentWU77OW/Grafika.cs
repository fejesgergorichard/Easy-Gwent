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

        Random r = new Random();
        int ertek { get; set; }
        string tipus { get; set; }

        public Grafika(Lap lap)
        {
            this.tipus = lap.Tipus.ToString();
            this.ertek = ((MezonyLap)lap).AktualisErtek;
        }

        public static void MezonyLapokatKirajzolTeszt()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;


            int y = 1;
            // 6 sort fogunk kirajzolni (játékosonként 3-3)
            for (int i = 0; i < 6; i++)
            {
                // Egy sor mezőny lap
                for (int j = 0; j < 5; j++)
                {
                    LapotKirajzol((j * (szelesseg + 2) + 1), y, new Grafika(new MezonyLap(LapTipus.Gyalogos, 9)));
                }
                Console.SetCursorPosition(0, y + magassag);
                Console.ForegroundColor = (i < 2) ? ConsoleColor.DarkGreen : ConsoleColor.DarkCyan;
                Console.Write("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                y += (i == 2) ? magassag + 2 : magassag + 1;
            }

            // Kézben lévő lapok
            KezbenLevoLapokatKirajzol();
        }

        public static void LapokHelyetKirajzolTeszt()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            int y = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    LapHelyetKirajzol((j * (szelesseg + 2) + 1), y);
                }
                Console.SetCursorPosition(0, y + 6);
                Console.ForegroundColor = (i > 2) ? ConsoleColor.DarkGreen : ConsoleColor.DarkCyan;
                Console.Write("------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                y += (i == 2) ? magassag + 2 : magassag + 1;
            }

            // Kézben lévő lapok
            KezbenLevoLapokatKirajzol();

        }

        private static int KezbenLevoLapokatKirajzol()
        {
            int y = kezbenLevoLapokY;
            for (int j = 0; j < 5; j++)
            {
                LapotKirajzol((j * (szelesseg + 2) + 1), y, new Grafika(new MezonyLap(LapTipus.Harcigep, 9)));
            }

            return y;
        }

        public static void LapotKirajzol(int x, int y, Grafika card)
        {
            Console.BackgroundColor = ConsoleColor.White;
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
            Console.Write(card.ertek);
            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write(card.tipus);
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
    }
}
