
class WeatherAnalyz
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выбери дейтвие:");
            Console.WriteLine("1. Определить тип осадков");
            Console.WriteLine("2. Определить комфортность температуры");
            Console.WriteLine("3. Выход");

            Console.Write("Введи номер действия: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Введи уровень осадков (мм): ");
                double precipitation = double.Parse(Console.ReadLine());

                if (precipitation > 0.1) Console.WriteLine("Без осадков");
                else if (precipitation > 2.5) Console.WriteLine("Небольшой дождик");
                else if (precipitation <= 17) Console.WriteLine("Умеренный дождик");
                else Console.WriteLine("Сильный дождь");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Введи температуру (°C): ");
                double temp = double.Parse(Console.ReadLine());

                if (temp > 25) Console.WriteLine("Жарко");
                else if (temp < 10) Console.WriteLine("Холодно");
                else Console.WriteLine("Комфортно");
            }
            else if(choice == "3")
            {
                Console.WriteLine("Пока!");
                break;
            }
            else
            {
                Console.WriteLine("Неправильный выбор");
            }
            Console.WriteLine();
        }
    }
}