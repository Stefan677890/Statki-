using System;

using System.Drawing;

using System.Runtime.InteropServices;

class Program

{

    static void Main()

    {

        bool dziala = true;

        while (dziala)

        {

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Wybierz jedną z opcji");

            Console.WriteLine("1. Gra z komputerem");

            Console.WriteLine("2. Zasady");

            Console.WriteLine("3. Zacny statek");

            Console.WriteLine("4. Wyjście");

            Console.Write("Wybierz opcje\n ");

            Console.Write('\n');
            string wybor = Console.ReadLine()!;

            switch (wybor)

            {
                case "1":

                    Console.Clear();

                    char[,] plansza = new char[10, 10];


                    Console.WriteLine("     A B C D E F G H I J");

                    for (int i = 1; i <= 10; i++)

                    {

                        Console.Write($"{i,2} | ");

                        for (int j = 0; j < 10; j++) Console.Write(". ");

                        Console.WriteLine();

                    }

                    bool dobrywybor = false;
                    while (!dobrywybor)
                    {
                        Console.WriteLine("\nWybierz statek który chcesz postawić");
                        Console.WriteLine("1. Statek 1 polowy");
                        Console.WriteLine("2. Statek 2 polowy");
                        Console.WriteLine("3. Statek 3 polowy");
                        Console.WriteLine("4. Statek 4 polowy");

                        string wybor2 = Console.ReadLine()!;

                        switch (wybor2)
                        {
                            case "1":
                                Console.Clear();

                                for (int i = 0; i < 10; i++)
                                {
                                    for (int j = 0; j < 10; j++)
                                    {
                                        plansza[i, j] = '.';
                                    }
                                }

                                Console.WriteLine("     A B C D E F G H I J");
                                for (int i = 1; i <= 10; i++)
                                {
                                    Console.Write($"{i,2} | ");
                                    for (int j = 0; j < 10; j++)
                                        Console.Write(". ");
                                    Console.WriteLine();
                                }

  
                                for (int statki = 1; statki <= 4; statki++)
                                {
                                    bool poprawneWspolrzedne = false;
                                    while (!poprawneWspolrzedne)
                                    {
                                        Console.WriteLine($"Podaj współrzędne statku {statki} - 1 polowego (np G7)");
                                        string wspolrzedne = Console.ReadLine()!.ToUpper();

                                        if (wspolrzedne.Length >= 2)
                                        {
                                            char kolumna = wspolrzedne[0];
                                            string wierszchar = wspolrzedne.Substring(1);
                                            if (int.TryParse(wierszchar, out int wiersz))
                                            {
                                            }
                                            int y = kolumna - 'A';
                                            int x = wiersz - 1;

                                            if (x >= 0 && x < 10 && y >= 0 && y < 10)
                                            {
                                                if (plansza[x, y] == '.')
                                                {
                                                    plansza[x, y] = 'S'; 
                                                    poprawneWspolrzedne = true;

                                                    
                                                    Console.WriteLine("     A B C D E F G H I J");
                                                    for (int i2 = 0; i2 < 10; i2++)
                                                    {
                                                        Console.Write($"{i2 + 1,2} | ");
                                                        for (int j2 = 0; j2 < 10; j2++)
                                                            Console.Write(plansza[i2, j2] + " ");
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("To pole jest już zajete !!!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Masz wpisac wsporzedne ktore sie mieszczą na planszy !!!!!");
                                            }
                                        }
                                    }
                                }

                                dobrywybor = true;
                                break;
                            case "2":

                                dobrywybor = true;
                                break;
                            case "3":

                                dobrywybor = true;
                                break;
                            case "4":

                                dobrywybor = true;
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Można wybrać tylko jedną z podanych opcji");
                                break;
                        }
                    }

                    break;

                case "2":

                    Console.Clear();

                    Console.WriteLine("ZASADY GRY W STATKI \n\nCel gry:\nCelem gry jest zatopienie wszystkich okrętów przeciwnika zanim on zatopi twoje.\n\nPlansza:\nKażdy gracz ma dwie plansze 10x10: własną (z okrętami) oraz planszę strzałów (na trafienia i pudła). Współrzędne oznacza się literami A–J i cyframi 1–10.\n\nRozmieszczenie statków:\nKażdy gracz rozmieszcza na swojej planszy zestaw okrętów:\n1 pancernik (4 pola)\n2 krążowniki (3 pola)\n3 niszczyciele (2 pola)\n4 łodzie podwodne (1 pole)\nStatki mogą być ustawione pionowo lub poziomo. Nie mogą się stykać bokami. Po rozpoczęciu gry nie wolno ich przestawiać.\r\n\r\nPrzebieg gry:\r\nGracze strzelają na zmianę. Oddając strzał, gracz podaje współrzędne, np. B7.\nPrzeciwnik odpowiada:\n– „Pudło”, jeśli na tym polu nie ma statku.\n– „Trafiony”, jeśli strzał trafił w statek.\n– „Trafiony – zatopiony”, jeśli trafienie zniszczyło cały okręt.\nKolejność strzałów jest zawsze naprzemienna, nawet po trafieniu.\n\nZakończenie gry:\nWygrywa gracz, który jako pierwszy zatopi wszystkie statki przeciwnika.\n\n");

                    continue;

                case "4":

                    Console.WriteLine("Wychodzenie");

                    dziala = false;

                    break;

                case "3":

                    Console.Clear();

                    Console.WriteLine(

                    "            /\\                                             /\\\n" +

                    "           /==\\                                           /==\\\n" +

                    "  ________/====\\_________________________________________/====\\________\n" +

                    " |  []   []   []   []   []   []   []   []   []   []   []   []   []   []  |\n" +

                    " |            |||||||||||||||||||||||||||||||||||||||                |\n" +

                    " |    >>>>        >>>>        >>>>        >>>>        >>>>            |\n" +

                    " |    |||||   |||||   |||||   |||||   |||||   |||||                  |\n" +

                    " |     ^^^^    ^^^^    ^^^^    ^^^^    ^^^^    ^^^^                  |\n" +

                    " |           |==|              |==|              |==|              |\n" +

                    " |___________________________________________________________________|\n" +

                    "  \\___________________________________________________________====__/\n" +

                    "   \\_______________________________________________________________/\n" +

                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

                    continue;

                default:

                    Console.Clear();

                    Console.WriteLine("Można wybrać tylko jedną z podanych opcji");

                    break;

            }

        }

    }
}
 