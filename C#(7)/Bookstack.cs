using System.Collections.Generic;

class Bookstack
{
    static void Main()
    {
        Stack<string> books = new Stack<string>();

        while (true)
        {
            Console.WriteLine("\n1. Добавить книгу на верх");
            Console.WriteLine("2. Убрать книгу сверху");
            Console.WriteLine("3. Посмотреть вверхнию книгу");
            Console.WriteLine("4. Вывести текущую стопку");
            Console.WriteLine("5. Выход");
            Console.Write("Выбери действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите название книги: ");
                    string bookAdd = Console.ReadLine();
                    books.Push(bookAdd);
                    Console.WriteLine($"Книга '{bookAdd}' добавлена на верх стопки");
                    break;

                case "2":
                    if (books.Count > 0)
                    {
                        string removeBook = books.Pop();
                        Console.WriteLine($"Убрана книга: '{removeBook}'");
                    }
                    else
                    {
                        Console.WriteLine("Стопка книг пуста!");
                    }
                    break;

                case "3":
                    if (books.Count > 0)
                    {
                        Console.WriteLine($"Текущая книга сверху: '{books.Peek()}'");
                    }
                    else
                    {
                        Console.WriteLine("Стопка книг пуста");
                    }
                    break;

                case "4":
                    Console.WriteLine("\nТекущая стопка книг (сверху вниз):");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"- {book}");
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
}