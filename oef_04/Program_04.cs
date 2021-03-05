using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oef_04
{
    class Program_04
    {
        static void Main(string[] args)
        {
            //Maak een array gevuld met willekeurige getallen tussen 1 en 100 (de array is 20 lang)


            //tss 1 en 100 (dus 2 kleinste, 99 grootste)
            int[] getallenArray = CreateArrayRandomInts(20, 2, 99);

            //-----------------------------------------------------------------------tonen
            for (int i = 0; i < getallenArray.Length; i++)
            {
                Console.WriteLine(getallenArray[i]);
            }
            //----------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("druk een toets om af te sluiten");
            Console.ReadKey();
        }

        //==========================================================================================================
        /// <summary>
        /// Deze methode creeerd een array van random integers
        /// </summary>
        /// <param name="aantalGetallen">aantal getallen dat gecreeerd wordt</param>
        /// <param name="onderInclusief">het laagste getal dat zal voorkomen in de array</param>
        /// <param name="bovenInclusief">het hoogste getal dat voorkomen in de array</param>
        /// <returns>array van integers met willekeurige waarde</returns>
        static int[] CreateArrayRandomInts(int aantalGetallen, int onderInclusief, int bovenInclusief)
        {
            Thread.Sleep(1); //anders genereerd deze 2 dezelfde arrays als je deze methode snel achter mekaar uitvoerd
            int[] terug = new int[aantalGetallen];
            Random r = new Random();

            for (int i = 0; i < aantalGetallen; i++)
                terug[i] = r.Next(onderInclusief, bovenInclusief+1);

            return terug;
        }
    }
}
