using System.Collections.Generic;


class GameInventory
{
    static void Main()
    {
        Dictionary<string, int> inventory = new Dictionary<string, int>()
        {
            { "Меч", 1},
            { "Щит", 2},
            { "Хилка", 5}
        };

        while (true)
        {
            Console.WriteLine("\n1. Добавить итем");
            Console.WriteLine("2. Удалить итем");
            Console.WriteLine("3. Просмотреть инвентарь");
            Console.WriteLine("4. Найти предмет");
            Console.WriteLine("5. Выход");
            Console.Write("Выбери действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введи название предмета: ");
                    string itemAdd = Console.ReadLine();
                    Console.Write("Введи количество: ");
                    int count = int.Parse(Console.ReadLine());

                    if (inventory.ContainsKey(itemAdd))
                    {
                        inventory[itemAdd] += count;
                    }
                    else
                    {
                        inventory[itemAdd] = count;
                    }
                    Console.WriteLine($"Предмет '{itemAdd}' добавлен в количестве {count}.");
                    break;

                    case "2":
                    Console.Write("Введите название предмета для удаления: ");
                    string itemRemove = Console.ReadLine();

                    if (inventory.ContainsKey(itemRemove))
                    {
                        Console.Write("Введи количество для удаления: ");
                        int removeCount = int.Parse(Console.ReadLine());

                        if (removeCount >= inventory[itemRemove])
                        {
                            inventory.Remove(itemRemove);
                            Console.WriteLine($"Предмет '{itemRemove}' полностью удален из инвентаря");
                        }
                        else
                        {
                            inventory[itemRemove] -= removeCount;
                            Console.WriteLine($"Удалено {removeCount} предметов '{itemRemove}'. Осталось: {inventory[itemRemove]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого предмета нет в инвентаре");
                    }
                    break;

                    case "3":
                    Console.WriteLine("\nТекущий инвентарь:");
                    foreach (var item in inventory)
                    {
                        Console.Write($"{item.Key}: {item.Value}");
                    }
                    break;

                    case "4":
                    Console.WriteLine("Введи название предмета для поиска: ");
                    string itemFind = Console.ReadLine();

                    if (inventory.TryGetValue(itemFind, out int itemCount))
                    {
                        Console.WriteLine($"Найдено: {itemFind} - {itemCount} штю");
                    }
                    else
                    {
                        Console.WriteLine("Предмет не найден");
                    }
                    break;

                    case "5":
                    return;

                    default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }
}