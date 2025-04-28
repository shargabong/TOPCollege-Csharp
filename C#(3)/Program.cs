class MARKS
{
    static void Main()
    {
        int[] MARKS = { 85, 92, 78, 90, 67 };
        int sum = 0;
        for (int i = 0; i < MARKS.Length; i++)
        {
            sum += MARKS[i];
        }
        double average = 1.0 * sum / MARKS.Length;
        Console.WriteLine($"Средняя оценка: {average}");

        int aboveaverage = 0;
        for (int i = 0; i < MARKS.Length; i++)
        {
            if (MARKS[i] > average)
                aboveaverage++;
        }
        Console.WriteLine($"Студентов с оценкой выше средней: {aboveaverage}");

        for (int i = 0; i < MARKS.Length - 1; i++)
        {
            for (int j = 0; j < MARKS.Length - 1; j++)
            {
                if (MARKS[j] > MARKS[j + 1])
                {
                    int temp = MARKS[j];
                    MARKS[j] = MARKS[j + 1];
                    MARKS[j + 1] = temp;
                }
            }
        }
        Console.Write("Оценки по возрастанию: ");
        for (int i = 0; i < MARKS.Length; i++)
        {
            Console.Write(MARKS[i]);
            if (i < MARKS.Length - 1)
            {
                Console.Write("");
            }
            Console.WriteLine();
        }
    }
}

class Uselesslabirintik
{
    static void Main()
    {
        int s = 5;
        int[,] m = new int[s, s];


        Console.WriteLine("Цифры 5 строк по 5 штук (0 или 1):");
        for (int i = 0; i < s; i++)
        {
            var r = Console.ReadLine();
            for (int j = 0; j < s; j++)
            {
                m[i, j] = r[j] == '1' ? 1 : 0;
            }
        }

        Console.WriteLine("\nКривой лабиринт:");
        for (int i = 0; i < s; i++)
        {
            for (int j = 0; j < s; j++)
            {
                Console.Write(m[i, j] + " ");
            }
            Console.WriteLine();
        }


        bool[,] v = new bool[s, s];
        bool f = false;


        int[] sx = new int[999];
        int[] sy = new int[999];
        int st = 0;

        sx[st] = 0; sy[st] = 0; st++;

        while (st > 0)
        {
            st--;
            int x = sx[st];
            int y = sy[st];


            if (x == s - 1 && y == s - 1)
            {
                f = true;
                break;
            }

            if (x < 0 || y < 0 || x >= s || y >= s) continue;
            if (m[x, y] == 1 || v[x, y]) continue;

            v[x, y] = true;

            sx[st] = x + 1; sy[st] = y; st++;
            sx[st] = x - 1; sy[st] = y; st++;
            sx[st] = x; sy[st] = y + 1; st++;
            sx[st] = x; sy[st] = y - 1; st++;
        }

        Console.WriteLine(f ? "\nЕсть путь!" : "\nНет пути!");
    }
}

class City
{
    static void Main()
    {
        int[][] c = {
            new int[] { 10000, 15000, 20000 },
            new int[] { 5000, 7000 },
            new int[] { 30000, 40000, 50000, 60000 }
        };

        int[] total = new int[c.Length];
        int maxTotal = 0;
        int maxIndex = 0;

        for (int i = 0; i < c.Length; i++)
        {
            total[i] = 0;

            for (int j = 0; j < c[i].Length; j++)
            {
                total[i] += c[i][j];
            }

            if (total[i] > maxTotal)
            {
                maxTotal = total[i];
                maxIndex = i;
            }
        }

        for (int i = 0; i < c.Length; i++)
        {
            Console.WriteLine($"Город {i + 1}: Общее население = {total[i]}");
        }

        Console.WriteLine($"Самый большой город: Город {maxIndex + 1}");
    }
}