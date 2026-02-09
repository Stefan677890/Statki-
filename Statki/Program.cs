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
                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            plansza[i, j] = '.';

                    Console.WriteLine("     A B C D E F G H I J");
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.Write($"{i,2} | ");
                        for (int j = 0; j < 10; j++) Console.Write(". ");
                        Console.WriteLine();
                    }

                    char[,] planszakomputera = new char[10, 10];
                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            planszakomputera[i, j] = '.';

                    statkikomputerwszystkie(planszakomputera);

                    bool dobrywybor = false;
                    while (!dobrywybor)
                    {
                        Console.WriteLine("\nWybierz statek który chcesz postawić");
                        Console.WriteLine("1. Statek 1 polowy");
                        Console.WriteLine("2. Statek 2 polowy");
                        Console.WriteLine("3. Statek 3 polowy");
                        Console.WriteLine("4. Statek 4 polowy \n");

                        string wybor2 = Console.ReadLine()!;

                        switch (wybor2)
                        {
                            case "1":
                                Console.Clear();

                                Console.WriteLine("     A B C D E F G H I J");
                                for (int i = 0; i < 10; i++)
                                {
                                    Console.Write($"{i + 1,2} | ");
                                    for (int j = 0; j < 10; j++)
                                    {
                                        Console.Write(plansza[i, j] + " ");
                                    }
                                    Console.WriteLine();
                                }

                                for (int statki = 1; statki <= 4; statki++)
                                {
                                    bool poprawnewspolrzedne = false;
                                    while (!poprawnewspolrzedne)
                                    {
                                        Console.WriteLine($"Podaj współrzędne statku {statki} - 1 polowego (np G7)");
                                        string wspolrzedne = Console.ReadLine()!.ToUpper();

                                        if (wspolrzedne.Length >= 2)
                                        {
                                            char kolumna = wspolrzedne[0];
                                            string wierszchar = wspolrzedne.Substring(1);
                                            if (int.TryParse(wierszchar, out int wiersz))
                                            {
                                                int y = kolumna - 'A';
                                                int x = wiersz - 1;

                                                Console.Clear();

                                                if (x >= 0 && x < 10 && y >= 0 && y < 10)
                                                {
                                                    if (plansza[x, y] == '.' && !cZybokisiestykja(plansza, x, y))
                                                    {
                                                        plansza[x, y] = 'S';
                                                        poprawnewspolrzedne = true;

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
                                                        Console.WriteLine("Statki nie moga sie stykać");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Masz wpisac wsporzedne ktore sie mieszczą na planszy !!!!!");
                                                }
                                            }
                                        }
                                    }
                                }
                                break;

                            case "2":
                                for (int statki = 1; statki <= 3; statki++)
                                {
                                    bool poprawnewspolrzedne = false;
                                    while (!poprawnewspolrzedne)
                                    {
                                        Console.WriteLine($"Podaj wspólrzędne statku {statki} - 2 polowego (np A1) \n");
                                        string wspolrzedne = Console.ReadLine()!.ToUpper();
                                        Console.WriteLine("Podaj orientację (h jesli chcesz ustawic poziomo i v jesli chcesz postawic pionowo \n");
                                        string orientacja = Console.ReadLine()!.ToUpper();
                                        bool poziomo = (orientacja == "H");

                                        if (wspolrzedne.Length >= 2)
                                        {
                                            int y = wspolrzedne[0] - 'A';
                                            if (int.TryParse(wspolrzedne.Substring(1), out int wiersz))
                                            {
                                                int x = wiersz - 1;
                                                if (moznapostawic(plansza, x, y, 2, poziomo))
                                                {
                                                    for (int i = 0; i < 2; i++)
                                                    {
                                                        if (poziomo) plansza[x, y + i] = 'S';
                                                        else plansza[x + i, y] = 'S';
                                                    }
                                                    poprawnewspolrzedne = true;
                                                    Console.Clear();
                                                    Console.WriteLine("     A B C D E F G H I J");
                                                    for (int i2 = 0; i2 < 10; i2++)
                                                    {
                                                        Console.Write($"{i2 + 1,2} | ");
                                                        for (int j2 = 0; j2 < 10; j2++) Console.Write(plansza[i2, j2] + " ");
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else Console.WriteLine("Statki nie mogą się stykać ani wystawać poza plansze!!!");
                                            }
                                        }
                                    }
                                }
                                break;

                            case "3":
                                for (int statki = 1; statki <= 2; statki++)
                                {
                                    bool poprawnewspolrzedne = false;
                                    while (!poprawnewspolrzedne)
                                    {
                                        Console.WriteLine($"Podaj współrzędne statku {statki} - 3 polowego (np B2) \n");
                                        string wspolrzedne = Console.ReadLine()!.ToUpper();
                                        Console.WriteLine("Podaj orientację (h jesli chcesz ustawic poziomo i v jesli chcesz postawic pionowo \n ");
                                        string orientacja = Console.ReadLine()!.ToUpper();
                                        bool poziomo = (orientacja == "H");

                                        if (wspolrzedne.Length >= 2)
                                        {
                                            int y = wspolrzedne[0] - 'A';
                                            if (int.TryParse(wspolrzedne.Substring(1), out int wiersz))
                                            {
                                                int x = wiersz - 1;
                                                if (moznapostawic(plansza, x, y, 3, poziomo))
                                                {
                                                    for (int i = 0; i < 3; i++)
                                                    {
                                                        if (poziomo) plansza[x, y + i] = 'S';
                                                        else plansza[x + i, y] = 'S';
                                                    }
                                                    poprawnewspolrzedne = true;
                                                    Console.Clear();
                                                    Console.WriteLine("     A B C D E F G H I J");
                                                    for (int i2 = 0; i2 < 10; i2++)
                                                    {
                                                        Console.Write($"{i2 + 1,2} | ");
                                                        for (int j2 = 0; j2 < 10; j2++) Console.Write(plansza[i2, j2] + " ");
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else Console.WriteLine("Statki nie mogą się stykać ani wystawać poza plansze!!!");
                                            }
                                        }
                                    }
                                }
                                break;

                            case "4":
                                bool poprawnaczworka = false;
                                while (!poprawnaczworka)
                                {
                                    Console.WriteLine($"Podaj współrzędne statku 4 polowego (np. C3)");
                                    string wspolrzedne = Console.ReadLine()!.ToUpper();
                                    Console.WriteLine("Podaj orientację (h jesli chcesz ustawic poziomo i v jesli chcesz postawic pionowo \n");
                                    string orientacja = Console.ReadLine()!.ToUpper();
                                    bool poziomo = (orientacja == "H");

                                    if (wspolrzedne.Length >= 2)
                                    {
                                        int y = wspolrzedne[0] - 'A';
                                        if (int.TryParse(wspolrzedne.Substring(1), out int wiersz))
                                        {
                                            int x = wiersz - 1;
                                            if (moznapostawic(plansza, x, y, 4, poziomo))
                                            {
                                                for (int i = 0; i < 4; i++)
                                                {
                                                    if (poziomo) plansza[x, y + i] = 'S';
                                                    else plansza[x + i, y] = 'S';
                                                }
                                                poprawnaczworka = true;
                                                Console.Clear();
                                                Console.WriteLine("     A B C D E F G H I J");
                                                for (int i2 = 0; i2 < 10; i2++)
                                                {
                                                    Console.Write($"{i2 + 1,2} | ");
                                                    for (int j2 = 0; j2 < 10; j2++) Console.Write(plansza[i2, j2] + " ");
                                                    Console.WriteLine();
                                                }
                                            }
                                            else Console.WriteLine("Statki nie mogą się stykać ani wystawać poza planszę!");
                                        }
                                    }
                                }
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
                    Console.WriteLine("ZASADY GRY W STATKI \n\nCel gry:\nCelem gry jest zatopienie wszystkich okrętów przeciwnika zanim on zatopi twoje.\n\nPlansza:\nKażdy gracz ma dwie plansze 10x10: własną (z okrętami) oraz planszę strzałów (na trafienia i pudła). Współrzędne oznacza się literami A–J i cyframi 1–10.\n\nRozmieszczenie statków:\nKażdy gracz rozmieszcza na swojej planszy zestaw okrętów:\n1 pancernik (4 pola)\n2 krążowniki (3 pola)\n3 niszczyciele (2 pola)\n4 łodzie podwodne (1 pole)\nStatki mogą być ustawione pionowo lub poziomo. Nie mogą się stykać bokami. Po rozpoczęciu gry nie wolno ich przestawiać.\r\n\r\nPrzebieg gry:\nGracze strzelają na zmianę. Oddając strzał, gracz podaje współrzędne, np. B7.\nPrzeciwnik odpowiada:\n– „Pudło”, jeśli na tym polu nie ma statku.\n– „Trafiony”, jeśli strzał trafił w statek.\n– „Trafiony – zatopiony”, jeśli trafienie zniszczyło cały okręt.\nKolejność strzałów jest zawsze naprzemienna, nawet po trafieniu.\n\nZakończenie gry:\nWygrywa gracz, który jako pierwszy zatopi wszystkie statki przeciwnika.\n\n");
                    continue;

                case "4":
                    Console.WriteLine("Wychodzenie");
                    dziala = false;
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine(
                        "             /\\                                           /\\\n" +
                        "            /==\\                                         /==\\\n" +
                        "  ________/====\\_________________________________________/====\\________\n" +
                        " |   []   []   []   []   []   []   []   []   []   []   []   []   []   []   |\n" +
                        " |                         |||||||||||||||||||||||||||||||||||||||                 |\n" +
                        " |     >>>>         >>>>         >>>>         >>>>         >>>>                    |\n" +
                        " |     |||||    |||||    |||||    |||||    |||||    |||||                          |\n" +
                        " |      ^^^^     ^^^^     ^^^^     ^^^^     ^^^^     ^^^^                          |\n" +
                        " |             |==|                |==|                |==|               |\n" +
                        " |___________________________________________________________________|\n" +
                        "   \\___________________________________________________________====__/\n" +
                        "    \\_______________________________________________________________/\n" +
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                    continue;

                default:
                    Console.Clear();
                    Console.WriteLine("Można wybrać tylko jedną z podanych opcji");
                    break;
            }
        }
    }

    static void statkikomputerwszystkie(char[,] plansza)
    {
        for (int i = 0; i < 1; i++) statkikomputer(plansza, 4);
        for (int i = 0; i < 2; i++) statkikomputer(plansza, 3);
        for (int i = 0; i < 3; i++) statkikomputer(plansza, 2);
        for (int i = 0; i < 4; i++) statkikomputer(plansza, 1);
    }

    static Random statkicomputer = new Random();

    static void statkikomputer(char[,] plansza, int rozmiar)
    {
        bool ustawiono = false;

        while (!ustawiono)
        {
            bool pionowo = statkicomputer.Next(2) == 0;
            int x = statkicomputer.Next(0, 10);
            int y = statkicomputer.Next(0, 10);

            if (pionowo && x + rozmiar > 10) continue;
            if (!pionowo && y + rozmiar > 10) continue;

            bool moze = true;

            for (int j = 0; j < rozmiar; j++)
            {
                int nx = x + (pionowo ? j : 0);
                int ny = y + (pionowo ? 0 : j);

                if (plansza[nx, ny] != '.' || cZybokisiestykja(plansza, nx, ny))
                {
                    moze = false;
                    break;
                }
            }

            if (moze)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    int nx = x + (pionowo ? j : 0);
                    int ny = y + (pionowo ? 0 : j);
                    plansza[nx, ny] = 'S';
                }
                ustawiono = true;
            }
        }
    }

    static bool cZybokisiestykja(char[,] plansza, int x, int y)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];

            if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10)
            {
                if (plansza[nx, ny] == 'S')
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool moznapostawic(char[,] plansza, int x, int y, int rozmiar, bool poziomo)
    {
        int maxx = plansza.GetLength(0);
        int maxy = plansza.GetLength(1);

        if (poziomo) { if (y + rozmiar > maxy) return false; }
        else { if (x + rozmiar > maxx) return false; }

        for (int i = 0; i < rozmiar; i++)
        {
            int curx = poziomo ? x : x + i;
            int cury = poziomo ? y + i : y;

            if (plansza[curx, cury] == 'S') return false;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int k = 0; k < 4; k++)
            {
                int nx = curx + dx[k];
                int ny = cury + dy[k];

                if (nx >= 0 && nx < maxx && ny >= 0 && ny < maxy)
                {
                    if (plansza[nx, ny] == 'S')
                    {
                        bool tensam = false;
                        for (int s = 0; s < rozmiar; s++)
                        {
                            if (nx == (poziomo ? x : x + s) && ny == (poziomo ? y + s : y))
                                tensam = true;
                        }
                        if (!tensam) return false;
                    }
                }
            }
        }
        return true;
    }
}
