using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyGwentWU77OW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(1000, 800);
            //Console.SetWindowSize(150, 60);
            Console.SetWindowSize(170, 55);
            //int x = 1;
            //int y = 1;
            //while(true)
            //{
            //    Thread.Sleep(200);
            //    Console.Clear();
            //    DrawCardBounds(x, y);
            //    x++;
            //    y++;
            //}

            DrawCards();

            Console.ReadLine();
            Console.Clear();

            DrawCards();
            Console.ReadLine();
        }

        static void DrawCards()
        {
            int y;
            for (y = 1; y < 43; y += 7)
            {
                for (int x = 1; x < 75; x += 13)
                {
                    DrawCard(x, y, new Card());
                }
                Console.SetCursorPosition(0, y + 6);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("--------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
            y = 45;
            for (int x = 1; x < 75; x += 13)
            {
                DrawCard(x, y, new Card());
            }

        }

        static void DrawCard(int x, int y, Card card)
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
            Console.Write(card.Value);
            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write(card.Type);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, 0);
        }
    }

    public class Card
    {
        static Random r = new Random();
        public int Value { get; private set; }
        public string Type { get; private set; }

        public Card()
        {
            this.Type = "Gyalogos";
            this.Value = r.Next(1, 11);
        }

    }
}
