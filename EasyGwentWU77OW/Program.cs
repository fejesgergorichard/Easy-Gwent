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
            Console.SetBufferSize(130, 40);
            Console.SetWindowSize(130, 40);

            Gwent jatek = new Gwent();
            jatek.Start();

        }


    }
}
