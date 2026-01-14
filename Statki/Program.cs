using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        bool dziala = true;

        while (dziala)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------" );
            Console.WriteLine("Wybierz jedną z opcji");
            Console.WriteLine("1. Gra z komputerem");
            Console.WriteLine("2. Zasady");
            Console.WriteLine("3. Wyjście");
            Console.WriteLine("4. Zacny statek");
            Console.Write("Wybierz opcje\n ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    char[,] plansza = new char[10, 10];
                    Console.WriteLine(plansza);

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("ZASADY GRY W STATKI \n\nCel gry:\nCelem gry jest zatopienie wszystkich okrętów przeciwnika zanim on zatopi twoje.\n\nPlansza:\nKażdy gracz ma dwie plansze 10x10: własną (z okrętami) oraz planszę strzałów (na trafienia i pudła). Współrzędne oznacza się literami A–J i cyframi 1–10.\n\nRozmieszczenie statków:\nKażdy gracz rozmieszcza na swojej planszy zestaw okrętów:\n1 pancernik (4 pola)\n2 krążowniki (3 pola)\n3 niszczyciele (2 pola)\n4 łodzie podwodne (1 pole)\nStatki mogą być ustawione pionowo lub poziomo. Nie mogą się stykać bokami. Po rozpoczęciu gry nie wolno ich przestawiać.\r\n\r\nPrzebieg gry:\r\nGracze strzelają na zmianę. Oddając strzał, gracz podaje współrzędne, np. B7.\r\nPrzeciwnik odpowiada:\r\n– „Pudło”, jeśli na tym polu nie ma statku.\r\n– „Trafiony”, jeśli strzał trafił w statek.\r\n– „Trafiony – zatopiony”, jeśli trafienie zniszczyło cały okręt.\r\nKolejność strzałów jest zawsze naprzemienna, nawet po trafieniu.\n\nZakończenie gry:\nWygrywa gracz, który jako pierwszy zatopi wszystkie statki przeciwnika.\n\n");
                    continue;

                case "3":
                    Console.WriteLine("Wychodzenie");
                    dziala = false;
                    break;

                case "4":
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
                    Console.WriteLine("Można wybrać tylko jedną z podanych opcji");
                    break;
            }
        }
    }
}























