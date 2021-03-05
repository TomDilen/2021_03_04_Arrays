using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oef_05
{
    class Program_05
    {
        static void Main(string[] args)
        {
            //Maak een array gevuld met afwisselnd true en false (de array is 30 lang)



            bool[] boolArray = new bool[30];

            //----------------------------------------------------------------array vullen
            for (int i = 0; i < boolArray.Length; i++)
            {
                boolArray[i] =( i%2 == 0);
            }

            //-----------------------------------------------------------------------tonen
            for (int i = 0; i < boolArray.Length; i++)
            {
                Console.WriteLine(boolArray[i]);
            }



            //----------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("druk een toets om af te sluiten");
            Console.ReadKey();
        }
    }
}
