using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oef_12_schuifpuzzel
{
    class Program
    {

        const ConsoleColor KLEUR_SPEELVELD = ConsoleColor.DarkGray;
        const ConsoleColor KLEUR_ONEVEN_STUKJE = ConsoleColor.White;
        const ConsoleColor KLEUR_EVEN_STUKJE = ConsoleColor.Red;
        const ConsoleColor KLEUR_LEEGVAKJE = ConsoleColor.Black;

        //const int DELAY_TSS_SHUFFLE = 200;


        static void Main(string[] args)
        {
            int[,] speelveld;
            int cols;     //max 20
            int rows;     //max 14
            int aantalShuffles;
            int delayTssShuffles;

            

            while (true)
            {
                Console.Clear();
                //----------------------------------------------------------keuzemenu

                cols = 3; rows = 3; aantalShuffles = 1; delayTssShuffles = 20;

                Console.WriteLine("OPGELET, input wordt nog niet gevalideerd!");
                Console.WriteLine("hoe kleiner je het font zet hoe meer rijen en kolommen je kan gebruiken");
                Console.WriteLine("de app getest met fontgrootte 16, de onderstaand kolom en rij maximums geven geen probleem");
                Console.WriteLine("indien de kolommen of rijen te groot zijn dan cracht het program, begin opnieuw met een kleiner");
                Console.WriteLine("font of een kleinere waarde voor kolommen of rijen.\n");


                Console.Write("geef het aantal kolommen (3-20): ");
                cols = Convert.ToInt32(Console.ReadLine());
                Console.Write("geef het aantal rijen (3-14): ");
                rows = Convert.ToInt32(Console.ReadLine());
                Console.Write("geef het aantal shuffles (1-∞): ");
                aantalShuffles = Convert.ToInt32(Console.ReadLine());
                Console.Write("geef een delay milliseconden tss shuffels (0=geen): ");
                delayTssShuffles = Convert.ToInt32(Console.ReadLine());

                Console.Clear();


                speelveld = InitSpeelveld(cols, rows);
                ShufflePuzzel(speelveld, delayTssShuffles, aantalShuffles);

                //-----------------------------------------------------------gameloop

                bool isGewonnenboodschapLatenzien = true;

                //de game loop van dit geweldig spel :-)
                while (!IsPuzzelOpgelost(speelveld))
                {
                    int[] mogelijkheden = ZoekSchuifMogelijkheden(speelveld);


                    Console.SetCursorPosition(Console.WindowWidth - 40, 3);
                    Console.WriteLine("geef 999 in om naar keuzemenu te gaan");
                    Console.SetCursorPosition(Console.WindowWidth - 40, 5);
                    Console.WriteLine("welk puzzelstukje wil je verschuiven? ");
                    TekenHorLijn(Console.WindowWidth - 40, 6, 28, ConsoleColor.Black);
                    Console.SetCursorPosition(Console.WindowWidth - 40, 6);
                    Console.Write("[");
                    for (int i = 0; i < mogelijkheden.Length; i++)
                    {
                        Console.Write(mogelijkheden[i]);
                        if (i < mogelijkheden.Length - 1) Console.Write(" - ");
                    }
                    Console.Write("] ");

                    int teVerschuivenStukje;
                    //had ook in volgende if mogen staan
                    bool success = Int32.TryParse(Console.ReadLine(), out teVerschuivenStukje); 

                    if (success)
                    {
                        if (teVerschuivenStukje == 999) { isGewonnenboodschapLatenzien = false; break; }

                        if (mogelijkheden.Contains(teVerschuivenStukje))
                        {
                            SchuifPuzzelstukje(speelveld, teVerschuivenStukje);
                            tekenSpeelveld(speelveld);
                            Console.Beep(600, 100); //OK toon
                        }
                        else
                        {
                            Console.Beep(200, 400); //foute invoer toon
                        }
                    }
                    else
                    {
                        Console.Beep(200, 400); //foute invoer toon
                    }

                }

                //staat enkel op true als  999 is ingegeven
                if (isGewonnenboodschapLatenzien) 
                {
                    ConsoleColor currentkleur = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.SetCursorPosition(Console.WindowWidth - 32, 10);
                    Console.WriteLine("u hebt gewonnen");
                    Console.WriteLine("\n\n");
                    Console.SetCursorPosition(Console.WindowWidth - 40, 12);
                    Console.WriteLine("druk een toets voor keuzemenu");


                    Console.ForegroundColor = currentkleur;

                    Console.Beep(300, 600);

                    Console.ReadKey();
                }
            }

        }

        //=============================================================================================================

        static int[,] InitSpeelveld(int aAantalKolommen, int aAantalRijen)
        {
            int[,] aSpeelveld = new int[aAantalKolommen, aAantalRijen];

            int teller = 1;
            for (int y = 0; y < aSpeelveld.GetLength(1); y++)
            {
                for (int x = 0; x < aSpeelveld.GetLength(0); x++)
                {
                    aSpeelveld[x, y] = teller++;
                }
            }

            tekenSpeelveld(aSpeelveld,true);
            return aSpeelveld;
        }
        

        //=============================================================================================================
        static void ShufflePuzzel(int[,] aSpeelveld, int aDelayTussenDeSchuivingen = 0, int aDiepte = 20)
        {
            bool currentCursorVisible = Console.CursorVisible;
            Console.CursorVisible = false;

            Random rand = new Random();

            for (int i = 0; i < aDiepte; i++)
            {
                int[] mogelijkheden = ZoekSchuifMogelijkheden(aSpeelveld);

                int randomIndex = rand.Next(0, mogelijkheden.Length );
                SchuifPuzzelstukje(aSpeelveld, mogelijkheden[randomIndex]);
                if (aDelayTussenDeSchuivingen != 0)
                {
                    Thread.Sleep(aDelayTussenDeSchuivingen);
                    tekenSpeelveld(aSpeelveld);
                }
            }
            if(aDelayTussenDeSchuivingen==0) tekenSpeelveld(aSpeelveld);

            Console.CursorVisible = currentCursorVisible;
        }

        //=============================================================================================================
        static void SchuifPuzzelstukje(int[,] aSpeelveld, int aWaardeTeSchuivenPuzzelStukje)
        {
            int xLeegPuzzelstukje = -1;
            int yLeegPuzzelstukje = -1;
            int xTeVerschuivenPuzzelstukje = -1;
            int yTeVerschuivenPuzzelstukje = -1;

            //leeg puzzelstukje zoeken 
            for (int y = 0; y < aSpeelveld.GetLength(1); y++)
                for (int x = 0; x < aSpeelveld.GetLength(0); x++)
                    if ((aSpeelveld.GetLength(0) * aSpeelveld.GetLength(1)) == aSpeelveld[x, y])
                    {
                        //dit is het lege vlakje
                        xLeegPuzzelstukje = x;
                        yLeegPuzzelstukje = y;
                        break;
                    }
            //stukje zoeken dat verschoven moet worden (argument)
            for (int y = 0; y < aSpeelveld.GetLength(1); y++)
                for (int x = 0; x < aSpeelveld.GetLength(0); x++)
                    if (aWaardeTeSchuivenPuzzelStukje == aSpeelveld[x, y])
                    {
                        //dit is het lege vlakje
                        xTeVerschuivenPuzzelstukje = x;
                        yTeVerschuivenPuzzelstukje = y;
                        break;
                    }
            //Debug.WriteLine($"xLeeg: {xLeegPuzzelstukje}  yLeeg: {yLeegPuzzelstukje}");
            //Debug.WriteLine($"xTeSchuiven: {xTeVerschuivenPuzzelstukje}  yTeSchuiven: {yTeVerschuivenPuzzelstukje}");

            //hier verwisselen we het stukje
            int tmp = aSpeelveld[xLeegPuzzelstukje, yLeegPuzzelstukje];
            aSpeelveld[xLeegPuzzelstukje, yLeegPuzzelstukje] = aSpeelveld[xTeVerschuivenPuzzelstukje, yTeVerschuivenPuzzelstukje];
            aSpeelveld[xTeVerschuivenPuzzelstukje, yTeVerschuivenPuzzelstukje] = tmp;


        }

        //=============================================================================================================
        static bool IsPuzzelOpgelost(int[,] aSpeelveld)
        {
            bool terug = true;

            int teller = 0;
            for (int y = 0; y < aSpeelveld.GetLength(1); y++)
            {
                for (int x = 0; x < aSpeelveld.GetLength(0); x++)
                {
                    if (++teller != aSpeelveld[x, y]) return false;
                }
            }

            return terug;
        }

        //=============================================================================================================
        /// <summary>
        /// return een array met de mogenlijkheden die er zijn om te schuiven
        /// de mogenlijkheden zijn de waardes van de vlakjes
        /// </summary>
        static int[] ZoekSchuifMogelijkheden(int[,] aSpeelveld)
        {
            int[] terug = new int[10];
            int teller = 0;

            for (int y = 0; y < aSpeelveld.GetLength(1); y++)
            {
                for (int x = 0; x < aSpeelveld.GetLength(0); x++)
                {
                    //dit is het lege vlakje
                    if ((aSpeelveld.GetLength(0) * aSpeelveld.GetLength(1)) == aSpeelveld[x, y]){
                        if (x > 0) terug[teller++] = aSpeelveld[x-1, y]; //linker vlakje toevoegen
                        if (x< aSpeelveld.GetLength(0)-1) terug[teller++] = aSpeelveld[x + 1, y]; //rechter vlakje toevoegen
                        if (y > 0) terug[teller++] = aSpeelveld[x, y-1]; //boven vlakje toevoegen
                        if (y < aSpeelveld.GetLength(1) - 1) terug[teller++] = aSpeelveld[x , y+1]; //onder vlakje toevoegen
                    }
                }
            }
            Array.Resize(ref terug, teller); //array inkrimpen indien nodig
            return terug;
        }


        //============================================================================================================
        static void tekenSpeelveld(int[,] aSpeelveld, bool aIsGrootVlakTekenen=false)
        {
            const int MARGIN_X = 6;
            const int MARGIN_Y = 3;
            const int BREEDTE_VLAKJE = 6;
            const int HOOGTE_VLAKJE = 3;
            const int HOR_SPATIE_TSS_VLAKJES = 2;
            const int VER_SPATIE_TSS_VLAKJES = 1;

            int ttBreedte;
            int ttHoogte;

            //tt breedte en hoogte berekenen
            ttBreedte = ((BREEDTE_VLAKJE + HOR_SPATIE_TSS_VLAKJES) * aSpeelveld.GetLength(0)) + HOR_SPATIE_TSS_VLAKJES;
            ttHoogte = ((HOOGTE_VLAKJE + VER_SPATIE_TSS_VLAKJES) * aSpeelveld.GetLength(1)) + VER_SPATIE_TSS_VLAKJES;

            Console.WindowWidth = ttBreedte + MARGIN_X + 45; // 45 is de tekstbreedte ongeveer
            Console.WindowHeight = ttHoogte + MARGIN_Y + 2;

            //groot vlak tekenen
            if(aIsGrootVlakTekenen)
                TekenVlak(MARGIN_X, MARGIN_Y, ttBreedte, ttHoogte, KLEUR_SPEELVELD);

            //de puzzelstukjes tekenen
            for (int y = 0; y < aSpeelveld.GetLength(1); y++)
            {
                for (int x = 0; x < aSpeelveld.GetLength(0); x++)
                {
                    //kleuren bepalen
                    ConsoleColor kleurAchtergrond;
                    ConsoleColor kleurTekst;



                    //het laatste blokje tekenen met de kleur KLEUR_LEEGVAKJE
                    if ((aSpeelveld.GetLength(0)*aSpeelveld.GetLength(1)) == aSpeelveld[x, y])
                    {
                        kleurAchtergrond = KLEUR_LEEGVAKJE;
                        kleurTekst = KLEUR_LEEGVAKJE;
                    }
                    else
                    {
                        if (aSpeelveld[x, y] % 2 == 0) kleurAchtergrond = KLEUR_EVEN_STUKJE;
                        else kleurAchtergrond = KLEUR_ONEVEN_STUKJE;
                        if (aSpeelveld[x, y] % 2 == 1) kleurTekst = KLEUR_EVEN_STUKJE;
                        else kleurTekst = KLEUR_ONEVEN_STUKJE;
                    }
                        
                    //achtergrond tekenen
                    TekenVlak(  MARGIN_X + (x * (BREEDTE_VLAKJE)) + ((x + 1) * HOR_SPATIE_TSS_VLAKJES), 
                                MARGIN_Y + (y * (HOOGTE_VLAKJE)) + ((y+1) * VER_SPATIE_TSS_VLAKJES), 
                                BREEDTE_VLAKJE, HOOGTE_VLAKJE , kleurAchtergrond);

                    //tekst tekenen
                    Console.ForegroundColor = kleurTekst;
                    Console.BackgroundColor = kleurAchtergrond;
                    int posXtekst = MARGIN_X + (x * (BREEDTE_VLAKJE)) + ((x + 1) * HOR_SPATIE_TSS_VLAKJES)+2;
                    int posYtekst = MARGIN_Y + (y * (HOOGTE_VLAKJE)) + ((y + 1) * VER_SPATIE_TSS_VLAKJES) + (HOOGTE_VLAKJE/2);
                    if (aSpeelveld[x, y] < 10) posXtekst++;
                    Console.SetCursorPosition(posXtekst, posYtekst);
                    Console.WriteLine(aSpeelveld[x,y]);
                    
                }
                
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        //============================================================================================================
        public static void TekenVlak(int x, int y, int breedte, int hoogte, ConsoleColor kleur)
        {
            ConsoleColor vorigeAchtergrondkleur = Console.BackgroundColor;
            ConsoleColor vorigeVoorgrondkleur = Console.ForegroundColor;
            Console.BackgroundColor = kleur;
            Console.ForegroundColor = kleur;
            for (int _x = x; _x < x + breedte; _x++)
            {
                for (int _y = y; _y < y + hoogte; _y++)
                {
                    Console.SetCursorPosition(_x, _y);
                    Console.Write(" ");
                }
            }
            Console.BackgroundColor = vorigeAchtergrondkleur;
            Console.ForegroundColor = vorigeVoorgrondkleur;
        }

        //=============================================================================================================
        public static void TekenHorLijn(int xBegin, int yBegin, int lengte, ConsoleColor kleur)
        {
            ConsoleColor vorigeAchtergrondkleur = Console.BackgroundColor;
            ConsoleColor vorigeVoorgrondkleur = Console.ForegroundColor;
            Console.BackgroundColor = kleur;
            Console.ForegroundColor = kleur;
            for (int _x = xBegin; _x < lengte + xBegin; _x++)
            {
                Console.SetCursorPosition(_x, yBegin);
                Console.Write(" ");
            }
            Console.BackgroundColor = vorigeAchtergrondkleur;
            Console.ForegroundColor = vorigeVoorgrondkleur;
        }


    }
}
