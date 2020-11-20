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
        public Jatekos Jatekos1 { get; private set; }
        public Jatekos Jatekos2 { get; private set; }

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
            Console.Write("Pakli létrehozása");
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }

            // Lapok kiosztása a játékosoknak
            Console.WriteLine();
            Console.Write("Lapok kiosztása");
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }

        }
    }
}
