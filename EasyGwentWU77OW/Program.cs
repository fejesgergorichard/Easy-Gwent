﻿using System;
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
            Console.SetBufferSize(140, 45);
            Console.SetWindowSize(150, 55);

            Gwent jatek = new Gwent();
            jatek.Start();
            Console.ReadLine();
            Console.Clear();

            LapGrafika.LapokHelyetKirajzolTeszt();

            Console.ReadLine();
            Console.Clear();

            LapGrafika.MezonyLapokatKirajzolTeszt();

            Console.ReadLine();

            Console.Clear();
            Console.ReadLine();
        }


    }
}
