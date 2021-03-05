using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oef_07
{
    class Program_07
    {
        static void Main(string[] args)
        {
            //Maak een programma dat aan de gebruiker vraagt om 2 keer 5 getallen in te
            //voeren.Bewaar de eerste reeks waarden in een array A, de tweede reeks waarden 
            //in array B. Maak een nieuwe array C aan die steeds de som bevat van het
            //respectievelijke element uit arrays A en B. Toon het resultaat

            int[] arrA = new int[5];
            int[] arrB = new int[arrA.Length];
            int[] arrSom;


            //=================================================================================code autogenerator
            SetArrayMetRandomInts(arrA, 1, 20);
            for (int i = 0; i < arrA.Length; i++) Console.WriteLine($"getal {i + 1}: {arrA[i]}");
            Console.WriteLine("-------------------");
            SetArrayMetRandomInts(arrB, 1, 20);
            for (int i = 0; i < arrB.Length; i++) Console.WriteLine($"getal {i + 1}: {arrB[i]}");
            //=============================================================================code manuele generator
            //for (int i = 0; i < arrA.Length + arrB.Length; i++)
            //{
            //    if (i < arrA.Length) //eerste 5 getallen
            //    {
            //        Console.Write($"getal {i+1}: ");
            //        int tmpGetal = Convert.ToInt32(Console.ReadLine());
            //        arrA[i] = tmpGetal;
            //    }
            //    else
            //    {
            //        Console.Write($"getal {i - arrA.Length + 1}: ");
            //        int tmpGetal = Convert.ToInt32(Console.ReadLine());
            //        arrB[i - arrA.Length] = tmpGetal;

            //    }
            //    if (i == arrA.Length - 1) { Console.WriteLine("-------------------"); }
            //}
            //===================================================================================================


            //------------------------------------------------------som in arraySom zetten

            arrSom = CreateSomVan2Arrays(arrA, arrB);

            Console.WriteLine("-------------------");
            //-------------------------------------------------------------resultaat tonen
            for (int i = 0; i < arrSom.Length; i++)
            {
                Console.WriteLine($"de som van {arrA[i]} en {arrB[i]} = {arrSom[i]}");
            }



            //----------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("druk een toets om af te sluiten");
            Console.ReadKey();
        }
        //==========================================================================================================
        /// <summary>
        /// deze geeft een nieuwe array terug waarvan de elementen van dezelfde index opgeteld zijn
        /// de lengte van het teruggeven array is de lengte van de korste array uit de argumenten
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        static int[] CreateSomVan2Arrays(int[] arr1, int[] arr2)
        {
            int[] terug = new int[Math.Min(arr1.Length, arr2.Length)];

            for (int i = 0; i < terug.Length; i++)
            {
                terug[i] = arr1[i] + arr2[i];
            }

            return terug;
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
