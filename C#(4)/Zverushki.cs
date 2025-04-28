//// Коллекции
using System.Collections.Generic;

//class Program1
//{
//    static void Main()
//    {
//        List<int> list = new List<int>();
//        List<int> list2 = new List<int> { 1, 2 };

//        list.Add(1);
//        list.AddRange(list2);
//        list.AddRange(new List<int> { 1, 2, 3 });

//        // list = {1,2,3}
//        list.Insert(1, 5); // {1,5,2,3}
//        list.InsertRange(1, new List<int> { 4, 5 }); // {1,4,5,2,3}

//        // {4,3,5,2,7,2}
//        list.Remove(2); // удаление первого значения 2 - {4,3,5,7,2}
//        list.RemoveAt(0); // удаление по индексу 0 - {3,5,2,7,2}
//        list.RemoveRange(1, 3); // {4,7,2}
//        list.RemoveAll(x => x % 2 == 0); // удаление всех четных чисел
//        list.Clear(); // удалить всё

//        bool res = list.Contains(1);
//        int num = list.Find(x => x % 2 == 0);
//        List<int> list3 = list.FindAll(x => x % 2 == 0);

//        // {4,3,5,2,7,2}
//        List<int> list4 = list.GetRange(1, 3); // {3,5,2}

//        list.Reverse(); // переворачивает лист
//    }
//}

//class Program2
//{
//    static void Main()
//    {
//        HashSet<int> list = new HashSet<int>(); // в множестве уникальные элементы

//        list.Add(10);
//        list.Add(1);
//        list.Add(3);

//        list.Remove(10); // удаление элемента

//        list.Clear();
//        bool res = list.Contains(10);

//        list.Count(); // количество элементов

//    }
//}

//class Program3
//{
//    static void Main()
//    {
//        Stack<int> stack = new Stack<int>();

//        stack.Push(1); // для добавления элемента
//        int r = stack.Pop(); // для удаления элемента
//        int q = stack.Peek(); // возвращает последний элемент, но не удаляет

//        stack.Clear();
//        bool w = stack.Contains(10);
//        int e = stack.Count();

//    }
//}

//class Program4
//{
//    static void Main()
//    {
//        Dictionary<string, int> dic = new Dictionary<string, int>();

//        dic.Add("Bob", 25);
//        dic.Add("Tom", 30);
//        dic.Add("Joe", 20);

//        dic["Bob"] = 33;
//        dic["Sam"] = 22;

//        dic.Remove("Joe");
//        dic.Clear();

//        dic.ContainsKey("Bob");
//        dic.ContainsValue(20);

//        bool res = dic.TryGetValue("Tom", out var age);

//        dic.Count();
//    }
//}

class Zverushki
{
    static List<string> zveri = new List<string>();

    static void Main()
    {
        Console.WriteLine("Приветствую в зоопарке!");

        zveri.Add("Дракон");
        zveri.Add("Единорог");
        zveri.Add("Грифон");
        zveri.Add("Минотавр");
        zveri.Add("Феникс");

        while (true)
        {
            Console.WriteLine("\nЧто нужно? Жми цифру:");
            Console.WriteLine("1 - Добавить живку");
            Console.WriteLine("2 - Удалить");
            Console.WriteLine("3 - Найти животное по букве");
            Console.WriteLine("4 - Показать всех животных");
            Console.WriteLine("5 - Уйти из зоопарка");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Как назовем? ");
                string newZver = Console.ReadLine();
                if (newZver != "" && newZver != null)
                {
                    zveri.Add(newZver);
                    Console.WriteLine("Теперь у нас есть " + newZver + "! Победа!");
                }
                else
                {
                    Console.WriteLine("Ты че? Давай нормальное имя");
                }
            }
            else if (choice == "2")
            {
                Console.Write("Какого тебе убрать? ");
                string zverToKill = Console.ReadLine();
                bool killed = false;

                for (int i = 0; i < zveri.Count; i++)
                {
                    if (zveri[i] == zverToKill)
                    {
                        zveri.RemoveAt(i);
                        i--;
                        killed = true;
                    }
                }
                if (killed)
                    Console.WriteLine(zverToKill + " больше нет!");
                else
                {
                    Console.WriteLine("Такого существа у нас нету, сори!");
                }
            }
            else if (choice == "3")
            {
                Console.Write("С какой буквы ищем? ");
                char bukva = Console.ReadLine()[0];

                List<string> found = new List<string>();

                foreach (string zver in zveri)
                {
                    if (zver.Length > 0 && zver[0] == bukva)
                        found.Add(zver);
                }
                if (found.Count > 0)
                {
                    Console.Write("Нашли на " + bukva + ": ");
                    for (int i = 0; i < found.Count; i++)
                    {
                        if (i > 0) Console.Write(", ");
                        Console.Write(found[i]);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Никого не нашли! Может, они сбежали?");
                }
            }
            else if (choice == "4")
            {
                if (zveri.Count == 0)
                {
                    Console.WriteLine("Зоопарк пуст! Все сбежали!");
                    continue;
                }
                for (int i = 0; i < zveri.Count; i++)
                {
                    for (int j = i + 1; j < zveri.Count; j++)
                    {
                        if (string.Compare(zveri[i], zveri[j]) > 0)
                        {
                            string temp = zveri[i];
                            zveri[i] = zveri[j];
                            zveri[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Список по алфавиту:");
                foreach (string zver in zveri)
                {
                    Console.WriteLine("- " + zver);
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("Беги, Форест, Беги!");
                break;
            }
            else
            {
                Console.WriteLine("Что ты тыкаешь? Нет такой цифры!");
            }
        }
    }
}
