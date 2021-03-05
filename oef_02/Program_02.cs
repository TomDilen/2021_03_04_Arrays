using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oef_02
{
    class Program_02
    {
        static void Main(string[] args)
        {
            //Maak een array gevuld met de getallen van 100 tot en met 1

            int[] getallenArray = new int[100];

            for (int i = 0; i < getallenArray.Length; i++)
            {
                getallenArray[i] = 100-i;
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
