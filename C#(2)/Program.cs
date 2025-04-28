/*class Program
{
    static void Main()
    {
        //for
        for (int i = 0; i < 10; i++) { }

        // while
        while (true) { }

        // do..while
        do { }
        while (true);

        //break, continue

        // foreach
        int[] num5 = [1, 2, 3];
        foreach (var num in num5)
        {
            Console.WriteLine(num);
        }


        int[] nums1 = new int[4];
        int[] nums2 = new int[4] { 1, 2, 3, 4 };
        int[] nums3 = new int[] { 1, 2, 3 };
        int[] nums4 = { 1, 2, 3 };

        int a = nums1[0]; // первый элемент
        int a1 = nums1[^1]; // последний элемент

        for (int i = 0; i < nums4.Length; i++) { }

        // двумерные массивы
        int[,] matrix =
        {
            {1, 2 },
            {1, 3 },
            {2, 3 }
        };

        // зубчастый массив
        int[][] jagged =
        {
            new int[] {1,2},
            new int[] {1,2,3,4},
            new int[] {1,2,3},
        };
    }
}*/


class KOSMOS
{
    static void Main()
    {
        int[] TOPLIVOLOSS = { 7, 12, 5, 9, 14, 6, 11, 8, 13, 10 };
        //int[] TOPLIVOLOSS = { 7, 12, 5, 9, 14, 6, 11, 8, 13, 10, 2, 3 }; <- топливо кончилось
        int TOPLIVO = 100;

        Console.WriteLine("Погна на Марс!");
        Console.WriteLine($"Запас топлива: {TOPLIVO}");

        for (int zone = 0; zone < 10; zone++)
        {
            TOPLIVO -= TOPLIVOLOSS[zone];

            if (TOPLIVO <= 0)
            {
                Console.WriteLine($"Зона {zone + 1}:  Израсходовано {TOPLIVOLOSS[zone]} единиц топлива.");

                Console.WriteLine("Топливо кончилось! ГГВП");
                return;
            }
            Console.WriteLine($"Зона {zone + 1}:  Израсходовано {TOPLIVOLOSS[zone]} ед. топлива. Осталось {TOPLIVO} ед.");
        }
        Console.WriteLine("Экспедиция успешно прошла все зоны!");
    }
}

class TREASURES
{
    static void Main()
    {
        int[] TREASURE1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
        int POPITKI = 0;
        int curindex = 0;

        Console.WriteLine("Поиск сокровищ, погна!");

        while (true)
        {
            POPITKI++;

            if (TREASURE1[curindex] == 1)
            {
                Console.WriteLine($"Сокровище найдено после {POPITKI} попыток");
                break;
            }
            curindex = (curindex + 1) % TREASURE1.Length;

            Console.WriteLine($"Копаем яму #{POPITKI}......... Сокровища нет");
        }
    }
}

class doWHILE
{
    static void Main()
    {
        const int SECRETKA = 52;
        int POPITKI = 0;

        Console.WriteLine("Здарова, землячок! Угадай число");
        Console.WriteLine("Попробуй угадать.");

        do
        {
            POPITKI++;
            Console.Write("Твоя догадка: ");
        }
        while (Console.ReadLine() != "52");

        Console.WriteLine($"конгратюлейшен! Ты отгадал число за {POPITKI} попыток");
    }
}

class KARTINI
{
    static void Main()
    {
        string[] KARTINKI = { "Мона Лиза", "Звездная ночь", "Утро в сосновом лесу", "Февральская лазурь", "Картины Австралийского художника" };
        int INDEX = 1;

        Console.WriteLine("Каталог картин в музее:");

        foreach (string KARTINK in KARTINKI)
        {
            Console.WriteLine($"Картина {INDEX}: {KARTINK}");
            INDEX++;
        }
    }
}