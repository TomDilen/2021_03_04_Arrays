using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oef_01
{
    class Program_01
    {
        static void Main(string[] args)
        {
            //Maak een array gevuld met de getallen 1 tot en met 10.

            int[] getallenArray = new int[10];

            for (int i = 0; i < getallenArray.Length; i++)
            {
                getallenArray[i] = i + 1;
            }

            //========================================tonen
            for (int i = 0; i < getallenArray.Length; i++)
            {
                Console.WriteLine(getallenArray[i]);
            }



            //----------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("druk een toets om af te sluiten");
            Console.ReadKey();
        }
    }
}
