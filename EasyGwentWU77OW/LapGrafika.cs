using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class LapGrafika
    {
        const int szelesseg = 11;
        const int magassag = 6;
        const int kezbenLevoLapokKoordinataja = 45;

        Random r = new Random();
        int ertek { get; set; }
        string tipus { get; set; }

        public LapGrafika(Lap lap)
        {
            this.tipus = lap.Tipus.ToString();
            this.ertek = ((MezonyLap)lap).AktualisErtek;
        }

        public static void MezonyLapokatKirajzol()
        {
            int y = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    LapotKirajzol((j * (szelesseg + 2) + 1), y, new LapGrafika(new MezonyLap(LapTipus.Gyalogos, 9)));
                }
                Console.SetCursorPosition(0, y + 6);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                y += magassag + 1;
            }

            // Kézben lévő lapok
            y = kezbenLevoLapokKoordinataja;
            for (int j = 0; j < 5; j++)
            {
                LapotKirajzol((j * (szelesseg + 2) + 1), y, new LapGrafika(new MezonyLap(LapTipus.Harcigep, 9)));
            }

        }

        public static void LapotKirajzol(int x, int y, LapGrafika card)
        {
            int cardWidth = 11;
            int cardHeight = 6;

            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < cardHeight; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < cardWidth; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + cardWidth, y + i);
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

        public static void LapHelyetKirajzol(int x, int y, LapGrafika card)
        {
            int cardWidth = 11;
            int cardHeight = 6;

            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < cardHeight; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < cardWidth; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + cardWidth, y + i);
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
    }
}
