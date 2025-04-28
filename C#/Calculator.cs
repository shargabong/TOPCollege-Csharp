/*class Program
{
    static void Main()
    {
        string greeting = "Привет";

        Console.WriteLine(greeting);
        //Console.ReadKey();
        Console.WriteLine($"Say hello - {greeting}");
        Console.WriteLine("Say hello - {0}, {1}", 5, 10);

        *//*        double enter = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(enter);*//*

        //Console.Clear();

        double n = 10, m = 5;

        double k = n % m;

        if (n < 10 && n > 0 || n > 1 || !(n > 2))
        {

        } else if (n > 20)
        {

        } else
        {

        }

        string res = (n % 2 == 0) ? "Четное" : "Нечетное";

        switch (n)
        {
            case 0:
                Console.WriteLine();
                break;
            case 5:
            case 10:
                
                break;
            default:
                break;
        }
    }

*//*  static void Main(string[] args)
    static int Main
    static int Main(string[] args)*//*
}*/

// Этап 1: Простой калькулик
/*class kal1
{
    static void Main()
    {
        Console.WriteLine("Здарова, землячки!");
        
        Console.Write("Введи первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Введи второе число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double PLUS = num1 + num2;

        Console.WriteLine($"Результат: {PLUS}");
    }
}*/

// Этап 2: Адвансед калькулик
class kal2
{
    static void Main()
    {
        Console.WriteLine("Здарова, землячки!");

        Console.Write("Введите первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Выберите операцию (+, -, *, /): ");
        char operation = Convert.ToChar(Console.ReadLine());

        double result = 0;

        if (operation == '+')
        {
            result = num1 + num2;
            Console.WriteLine($"Результат: {result}");
        }
        else if (operation == '-')
        {
            result = num1 - num2;
            Console.WriteLine($"Результат: {result}");
        }
        else if (operation == '*')
        {
            result = num1 * num2;
            Console.WriteLine($"Результат: {result}");
        }
        else if (operation == '/')
        {
            if (num2 != 0)
            {
                result = num1 / num2;
                Console.WriteLine($"Результат: {result}");
            }
            else
            {
                Console.WriteLine("Ошибка: деление на ноль");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: неизвестная операция");
        }

        Console.WriteLine("\nТыкни любую клавишу, чтобы выйти");
        Console.ReadKey();
        Console.Clear();
    }
}


// парсинг
// int a = int.Parse("10");
// double b = double.Parse("23,56");
// string? input = Console.ReadLine();
// bool result = int.TryParse(input, out var number);
// if (reult == true)
// Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
// else
// Console.WriteLine("Преобразование завершилось неудачно");
