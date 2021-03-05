using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oef_03
{
    class Program
    {
        static void Main(string[] args)
        {

            //Maak een array gevuld met de letters a tot en met z

            char[] charArray = new char['z' - 'a' + 1];
            //char[] getallenArray = { 'a', 'b', 'c' };


            for (int i = 0; i < charArray.Length; i++)
            {
                char c = 'a';
                c += (char)i;
                charArray[i] = c;
            }

            //========================================tonen
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i]);
            }
            Console.WriteLine();


            //----------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("druk een toets om af te sluiten");
            Console.ReadKey();
        }
    }
}
