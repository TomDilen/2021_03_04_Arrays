using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oef_09
{
    class Program_09
    {
        static void Main(string[] args)
        {
            //Maak een programma dat eerst weer aan de gebruiker om 10 waarden vraagt die in
            //een array worden gezet

            //Vervolgens vraagt het programma welke waarde verwijderd moet worden.Wanneer
            //de gebruiker hierop antwoordt met een nieuwe waarde dan zal deze nieuw
            //ingevoerde waarde in de array gezocht worden. Indien deze gevonden wordt dan
            //wordt deze waarde uit de array verwijderd en worden alle waarden die erachter
            //komen met een plaatsje naar links opgeschoven, zodat achteraan de array terug
            //een lege plek komt.
            //Deze laatste plek krijgt de waarde -1.
            //Toon vervolgens alle waarden van de array.
            //Indien de te zoeken waarde meer dan 1 keer voorkomt, wordt enkel de eerst
            //gevonden waarde verwijderd


            int[] getallenArray = new int[10];

            //=================================================================================code autogenerator

            SetArrayMetRandomInts(getallenArray, 1, 20);
            for (int i = 0; i < getallenArray.Length; i++) Console.WriteLine($"getal {i + 1}: {getallenArray[i]}");

        }
        //==========================================================================================================
        /// <summary>
        /// Deze methode initialiseerd een array met  random integers
        /// </summary>
        static void RemoveFirstValueAndsetLastOnMinOne(int[] arrayVanIntegers, int waarde)
        {

            for (int i = 0; i < arrayVanIntegers.Length; i++) { 

            }
                

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
