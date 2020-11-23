using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EasyGwentWU77OW
{
    class Gwent
    {
        Random r = new Random();
        Lap[] pakli = new Lap[30];
        Jatekos Jatekos1 { get; set; }
        Jatekos Jatekos2 { get; set; }
        Csatamezo Csatamezo = new Csatamezo();

        /// <summary>
        /// Játék indítása.
        /// </summary>
        public void Start()
        {
            Console.Clear();
            Console.WriteLine(
                                                @"
                                                   {}
                                   ,   A           {}
                                  / \, | ,        .--.
                                 |    =|= >      /.--.\
                                  \ /` | `       |====|
                                   `   |         |`::`|  
                                       |     .-;`\..../`;_.-^-._
                                      /\\/  /  |...::..|`   :   `|
                                      |:'\ |   /'''::''|   .:.   |
                                       \ /\;-,/\   ::  |..GWENT..|
                                       |\ <` >  >._::_.| ':   :' |
                                       | `""""`  /   ^^  |   ':'   |
                                       |       |       \    :    /
                                       |       |        \   :   / 
                                       |       |___/\___|`-.:.-`
                                       |        \_ || _/    `
                                       |        <_ >< _>
                                       |        |  ||  |
                                       |        |  ||  |
                                       |       _\.:||:./_
                                       |      /____/\____\");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t\t\t\t\t   - EASY GWENT -\n\n");
            Console.WriteLine("\t\t\t\t\t   1 - Új játék");
            Console.WriteLine("\t\t\t\t\t   2 - Ismertető");
            Console.WriteLine("\t\t\t\t\t   3 - Kilépés\n\n");
            string valasztas;
            do
            {
                Console.Write("Válassz egy opciót: ");
                valasztas = Console.ReadLine();
            }
            while (valasztas == null || valasztas == "" || (valasztas != "1" && valasztas != "2" && valasztas != "3"));
            if (valasztas == "2")
            {
                Grafika.Szabalyok();
                Console.ReadLine();
                Start();
            }
            else if (valasztas == "3")
            {
                Kilepes();
            }
            else
            {
                JatekLoop();
            }
        }

        /// <summary>
        /// Létrehozza a játékosokat és kiosztja a lapokat.
        /// </summary>
        private void JatekInit()
        {
            // Játékos 1 létrehozása
            string nev;
            do
            {
                Console.Write("Játékos 1 neve: ");
                nev = Console.ReadLine();
            }
            while (nev == null || nev == "" || nev.Length > 20);
            Jatekos1 = new Jatekos(nev);

            // Játékos 2 létrehozása
            nev = null;
            do
            {
                Console.Write("Játékos 2 neve: ");
                nev = Console.ReadLine();
            }
            while (nev == null || nev == "" || nev == Jatekos1.Nev || nev.Length > 20);
            Jatekos2 = new Jatekos(nev);

            // Pakli generálás
            Console.WriteLine();
            Console.Write("Pakli létrehozása és keverése");
            PakliGeneralas();
            Kever();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(150);
                Console.Write(".");
            }

            // Lapok kiosztása a játékosoknak
            Console.WriteLine();
            Console.Write("Lapok kiosztása a játékosoknak");
            LapokatKioszt();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(150);
                Console.Write(".");
            }

            Console.WriteLine();
            Console.WriteLine("A játék készen áll. Üss entert a kezdéshez!");
            Console.ReadLine();
        }

        /// <summary>
        /// A játék fő loopja. Mindaddig ismétlődik, amíg valamelyik játékosnak van élete és a felhasználó játszani akar.
        /// </summary>
        private void JatekLoop()
        {
            JatekInit();
            // Amíg nem 0 élet van valakinél, addig ismétlődjön
            // kirajzoljuk az állapotot, megkérdezzük a játékost 5x hogy az adott lapot lerakja-e. a kijelölt lap sárga lesz
            //// minden eldöntés után aktiváljuk az időjárás lapokat majd újra rajzolunk
            // Utána a másiknál ugyanezt eljátsszuk és a végén kiírjuk hogy ki nyert
            while (Jatekos1.EletekSzama > 0 && Jatekos2.EletekSzama > 0)
            {
                // Kiürítjük a csatamezőt
                Csatamezo.Tisztit();

                // Játékos 1 húz, majd dönt 5 alkalommal
                Jatekos1.Felhuz();
                JatekosKore(Jatekos1, Csatamezo.J1Lapjai);

                // Játékos 2 lapot húz, majd dönt 5 alkalommal
                Jatekos2.Felhuz();
                JatekosKore(Jatekos2, Csatamezo.J2Lapjai);

                // Kör végi kiértékelés
                KorvegiKiertekeles();
            }

            // Játék végi kiértékelés
            JatekvegiKiertekeles();
        }

        /// <summary>
        /// Egy játékos köre. Ebben a körben dönthet minden kézben lévő lapról, hogy lerakja-e vagy sem.
        /// </summary>
        /// <param name="jatekos">A soron következő játékos.</param>
        /// <param name="elhelyezettLapjai">Az őáltala lerakott lapok helye a csatamezőn.</param>
        private void JatekosKore(Jatekos jatekos, MezonyLap[] elhelyezettLapjai)
        {
            for (int i = 0; i < jatekos.KezbenLevoLapok.Length; i++)
            {
                string bemenet;
                Console.Clear();
                Grafika.CsatamezotKirajzol(Csatamezo, Jatekos1, Jatekos2);
                Grafika.KezbenLevoLapokatKirajzol(jatekos, i);
                Console.SetCursorPosition(0, 32);
                Console.WriteLine($"{jatekos.Nev} köre.\nLerakod a kijelölt {jatekos.KezbenLevoLapok[i].Tipus.ToString()} lapot? (I/N)");
                do
                {
                    Console.SetCursorPosition(0, 35);
                    bemenet = Console.ReadLine();
                } while (bemenet.ToLower() != "i" && bemenet.ToLower() != "n");

                if (bemenet.ToLower() == "i")
                {
                    if (jatekos.KezbenLevoLapok[i] is MezonyLap)
                    {
                        int x = Csatamezo.ElhelyezettLapokTipusbol(jatekos.KezbenLevoLapok[i].Tipus);
                        if (x < 5)
                        {
                            elhelyezettLapjai[i] = (MezonyLap)jatekos.KezbenLevoLapok[i];
                            jatekos.KezbenLevoLapok[i] = null;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 35);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Nem helyezhetsz el több {jatekos.KezbenLevoLapok[i].Tipus} lapot.");
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        int x = Csatamezo.SzabadIdojarasKoordinata();
                        if (x < 5)
                        {
                            Csatamezo.IdojarasLapok[x] = (IdojarasLap)jatekos.KezbenLevoLapok[i];
                            jatekos.KezbenLevoLapok[i] = null;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 35);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nem helyezhetsz el több időjárás lapot.");
                            Thread.Sleep(1000);
                        }
                    }
                }
                Csatamezo.IdojarasLapokatAktival();
            }
        }

        /// <summary>
        /// Kiértékeli a játék (háború) eredményét és kiírja hogy ki nyert.
        /// </summary>
        private void JatekvegiKiertekeles()
        {
            if (Jatekos1.EletekSzama > Jatekos2.EletekSzama)
            {
                Console.WriteLine($"{Jatekos1.Nev} nyerte a háborút.");
            }
            else if (Jatekos1.EletekSzama < Jatekos2.EletekSzama)
            {
                Console.WriteLine($"{Jatekos2.Nev} nyerte a háborút.");
            }
            else
            {
                Console.WriteLine("Döntetlen.");
            }

            // Új játék?
            string be;
            Console.SetCursorPosition(0, 36);
            Console.WriteLine("Szeretnél újra játszani? (I/N)");
            do
            {
                Console.SetCursorPosition(0, 37);
                be = Console.ReadLine();
            } while (be.ToLower() != "i" && be.ToLower() != "n");

            if (be.ToLower() == "i")
            {
                JatekLoop();
            }
            else
            {
                Kilepes();
            }
        }

        private static void Kilepes()
        {
            Console.WriteLine("Viszlát!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        /// <summary>
        /// Kiértékeli a kör végén, mely játékos nyert és kiírja az eredményt.
        /// </summary>
        private void KorvegiKiertekeles()
        {
            Console.Clear();
            Grafika.CsatamezotKirajzol(Csatamezo, Jatekos1, Jatekos2);
            Console.SetCursorPosition(0, 32);
            if (Csatamezo.Jatekos1Pontjai == Csatamezo.Jatekos2Pontjai)
            {
                if (Jatekos1.Nev.ToLower() == "nilfgaardian")
                {
                    Console.WriteLine($"{Jatekos1.Nev} nyerte ezt a csatát {Csatamezo.Jatekos1Pontjai} ponttal, mert ő nilfgaardi.");
                    Jatekos2.EletekSzama--;
                }
                else if (Jatekos2.Nev.ToLower() == "nilfgaardian")
                {
                    Console.WriteLine($"{Jatekos2.Nev} nyerte ezt a csatát {Csatamezo.Jatekos2Pontjai} ponttal, mert ő nilfgaardi.");
                    Jatekos1.EletekSzama--;
                }
                else
                {
                    Console.WriteLine($"Ebben az ütközetben mindkét sereg odaveszett.");
                    Jatekos1.EletekSzama--;
                    Jatekos2.EletekSzama--;
                }
            }
            else if (Csatamezo.Jatekos1Pontjai < Csatamezo.Jatekos2Pontjai)
            {
                Console.WriteLine($"{Jatekos2.Nev} nyerte ezt a csatát {Csatamezo.Jatekos2Pontjai} ponttal.");
                Jatekos1.EletekSzama--;
            }
            else
            {
                Console.WriteLine($"{Jatekos1.Nev} nyerte ezt a csatát {Csatamezo.Jatekos1Pontjai} ponttal.");
                Jatekos2.EletekSzama--;
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Legenerálja a játék paklit.
        /// </summary>
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

        /// <summary>
        /// Megkeveri a paklit.
        /// </summary>
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

        /// <summary>
        /// Megcseréli a pakli két elemét.
        /// </summary>
        /// <param name="i">Első elem indexe</param>
        /// <param name="j">Második elem indexe</param>
        /// <param name="pakli">Lap[] tömb, amiben meg akarjuk cserélni a két elemet.</param>
        private void Csere(int i, int j, Lap[] pakli)
        {
            Lap tmp = pakli[i];
            pakli[i] = pakli[j];
            pakli[j] = tmp;
        }

        /// <summary>
        /// Kiosztja a lapokat a két játékos részére.
        /// </summary>
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
