class Filmoteka
{
    static void Main()
    {
        string[][] movies =
    {
        new string[] {"Матрица", "Интерстеллар", "Время"},
        new string[] {"Крёстный отец", "Казино", "Славные парни"},
        new string[] {"Аватар", "Спайдермэн", "Железный человек" }
    };

        string[] genre = { "Фэнтэзи", "Криминал", "Экшн" };

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{genre[i]}: - {movies[i][0]} - {movies[i][1]} - {movies[i][2]}");
            Console.WriteLine();
        }
    }
}
