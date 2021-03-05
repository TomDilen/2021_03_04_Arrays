using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_03_04_Arrays
{
    class Program
    {
        enum test
        {
            een = 1,
            twee = 2,
            drie = 3,
        }
        enum test2
        {
            een = 11,
            twee = 12,
            drie = 13,
        }
        static void Main(string[] args)
        {
            //strings staan op de stack niet op de heap
            //array van karakters staat wel in de heap

            Console.WriteLine();


            //int[] arrInts;

            //bool[] arrBools;

            //double[] arrDoubles;

            //string[] kleuren;
            //kleuren =  new string[] { "rood", "oranje", "geel", "wit" };

            //foreach (var item in kleuren)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("======================================");

            //int[] arr={ 5, 10, 20, 30 };

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Array.Clear(arr, 0, 2);

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //string teststring = "ik ben tom";
            //char chr = teststring[0];
            //Console.WriteLine(chr);

            //Console.WriteLine(arr.Max());
            //Console.WriteLine(arr.Reverse());



            char[] charArray1 = { 't', 'o', 'm' };
            char[] charArray2 = charArray1; //{ 't', 'o', 'm' };

            charArray1[0] = 'F';

            Console.WriteLine(charArray1);
            Console.WriteLine(charArray2);

            Console.WriteLine("-----------------------");

            string str1 = "tom";
            string str2 = "tom";

            //dit gaat niet
            //char c = str1[0];// = 'F';

            Console.WriteLine("==================================");

            int[] arr = { 5, 10, 20, 30 };

            Array.Clear(arr, 0, 2);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            


            Console.ReadKey();

        }
    }
}
