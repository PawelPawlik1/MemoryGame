using System;
using System.Linq;

namespace Matching4
{
    class Program
    {
        static void wyswietl(string[,] tab)
        {

            Console.WriteLine("      1     2     3     4 \n");
            //Console.WriteLine("----------");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(i + 1 + "  |  ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(tab[i, j] + "  |  ");
                }
                Console.WriteLine("\n\n");
            }
        }
        // static Boolean CzyTakieSame(string[,] tab)
        // {
        //     return tab[1, 3] == tab[1, 1];
        // }


        static void Main(string[] args)
        {

            string[,] tab2 = new string[4, 4] {
           { "*", "*", "*", "*"},
           { "*", "*", "*", "*"},
           { "*", "*", "*", "*"},
           { "*", "*", "*", "*"}
            };
            //  Console.WriteLine(CzyTakieSame(tab2));

            string[,] tabpom = new string[4, 4] {
           { "*", "*", "*", "*"},
           { "*", "*", "*", "*"},
           { "*", "*", "*", "*"},
           { "*", "*", "*", "*"}
            };

            string[,] zagadka = new string[4, 4] {
           {"a", "a", "b", "b"},
           {"c", "c", "d", "d"},
           {"e", "e", "f", "f"},
           {"g", "g", "h", "h"}
            };

            wyswietl(tab2);
            //data 1 = tabpom, data 2 = zagadka
            var equal = false;


            while (!equal)
            {
                Console.WriteLine("\nOdkryj karte. Podaj wspolrzedne: ");
                int a1 = int.Parse(Console.ReadLine()) - 1;
                int b1 = int.Parse(Console.ReadLine()) - 1;
                tab2[a1, b1] = zagadka[a1, b1];
                //Console.WriteLine("Wyswietlam tab2");
                wyswietl(tab2);
                int a2 = int.Parse(Console.ReadLine()) - 1;
                int b2 = int.Parse(Console.ReadLine()) - 1;

                tab2[a2, b2] = zagadka[a2, b2];
                //console.writeline("wyswietlam tab2");
                wyswietl(tab2);

                if (tab2[a1, b1] == tab2[a2, b2])
                {
                    tabpom[a1, b1] = tab2[a1, b1];
                    tabpom[a2, b2] = tab2[a2, b2];
                    Console.WriteLine("--------");
                    Console.WriteLine("Powyzsze karty sa rowne.");
                    wyswietl(tabpom);
                    // Console.WriteLine("--------");
                    equal = tabpom.Rank == zagadka.Rank &&
                    Enumerable.Range(0, tabpom.Rank).All(dimension => tabpom.GetLength(dimension) == zagadka.GetLength(dimension)) &&
                     tabpom.Cast<string>().SequenceEqual(zagadka.Cast<string>());

                }

                else
                {
                    Console.WriteLine("Niestety, te dwie karty roznia sie. Sprobuj ponownie");
                    tab2[a1, b1] = "*";
                    tab2[a2, b2] = "*";
                    Console.WriteLine("Tablica po usunieciu niesparowanych kart: ");
                    wyswietl(tab2);
                }


            }
            Console.WriteLine("Brawo, wygrales!");
        }
    }
}
