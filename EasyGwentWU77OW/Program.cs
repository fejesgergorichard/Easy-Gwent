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
            Console.SetWindowSize(170, 55);
            //Console.SetWindowSize(150, 60); 


            LapGrafika.MezonyLapokatKirajzol();

            Console.ReadLine();
            Console.Clear();

            LapGrafika.MezonyLapokatKirajzol();
            Console.ReadLine();
        }


    }
}
