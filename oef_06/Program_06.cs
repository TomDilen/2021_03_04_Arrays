using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oef_06
{
    class Program_06
    {
        static void Main(string[] args)
        {
            //Laat de gebruiker 10 getallen invoeren. Laat daarna de som, het gemiddelde en het
            //grootste getal zien.
            //Voer daarna nog een getal in. Het programma laat alle getallen zien die groter of
            //gelijk aan dit getal zijn.
            //Indien geen getallen groter zijn dan verschijnt een bericht “Niets is groter” op het
            //scherm.


            double inputGetal;
            int[] getallenArray = new int[10];

            //=================================================================================code autogenerator

            SetArrayMetRandomInts(getallenArray, 1, 20);
            for (int i = 0; i < getallenArray.Length; i++)  Console.WriteLine($"getal {i + 1}: {getallenArray[i]}");
            //=============================================================================code manuele generator

            //for (int i = 0; i < getallenArray.Length; i++)
            //{
            //    Console.Write($"getal {i + 1}: ");
            //    getallenArray[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //===================================================================================================



            //-------------------------------------------------------------------resultaat tonen
            Console.WriteLine("------------------------------");
            Console.WriteLine("De som van de invoer: " + getallenArray.Sum());
            Console.WriteLine("Gemiddelde van de invoer: " + getallenArray.Average());
            Console.WriteLine("grootste getal van de invoer: " + getallenArray.Max());
            Console.WriteLine("------------------------------");

            //------------------------------------------------------------- nog een getal vragen

            Console.Write("geef nog een getal in: ");
            inputGetal = Convert.ToInt32(Console.ReadLine());


            bool groterGevonden = false;
            bool groterOfGelijkGevonden = false;

            for (int i = 0; i < getallenArray.Length; i++)
            {
                if(getallenArray[i] >= inputGetal)
                {
                    groterOfGelijkGevonden = true;
                    if (getallenArray[i] > inputGetal)
                    {
                        groterGevonden = true;
                        break;
                    }
                }
            }

            if (groterOfGelijkGevonden) {
                Console.Write($"getallen die groter of gelijk zijn aan {inputGetal}: ");

                for (int i = 0; i < getallenArray.Length; i++)
                {
                    if (getallenArray[i] >= inputGetal) Console.Write("  " + getallenArray[i]);
                }

                Console.WriteLine();
            }
            if( !groterGevonden)
            {
                Console.WriteLine($"geen getallen gevonden die groter zijn dan {inputGetal}");
            }



            //----------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("druk een toets om af te sluiten");
            Console.ReadKey();

        }

        //==========================================================================================================
        /// <summary>
        /// Deze methode initialiseerd een array met  random integers
        /// </summary>
        static void SetArrayMetRandomInts(int[] arrayVanIntegers, int onderInclusief, int bovenInclusief)
        {
            Thread.Sleep(1); //anders genereerd deze 2 dezelfde arrays als je deze methode snel achter mekaar uitvoerd
            Random r = new Random();

            for (int i = 0; i < arrayVanIntegers.Length; i++)
                arrayVanIntegers[i] = r.Next(onderInclusief, bovenInclusief + 1);

        }

    }
}
