// асинхронное программирование - подхот написания кода, при котором выполнение некоторых операций
// выносится из основного потока выполнения программы

// синхронное - когда операция выполняеются последовательно (после выполнения предыдущей операции)
// асинхронное - некоторые операции (долгие) выполняются паралельно с основным потоком
//
// когда асинхронность: ввод-вывод (сеть, бд, загрузка с серверов), долгие вычисления (сложные расчеты),
// улучшение отзывчивости приложений
//
// task - операция, которая не возвращает значения
// используется как тип возвр значения у асинхронных методов

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//class Program
//{
//    static void Main()
//    {
        //Console.WriteLine(1);
        //Console.WriteLine(1);
        //Console.WriteLine(1);
//        Method();
        //Console.WriteLine(1);
        //Console.WriteLine(1);
        //Console.WriteLine(1);
//    }

 //   static async void Method()
 //   {
        //Task task = Task.Delay(2000); // task - операция, которая не возвращает значения
        //Task<int> task = Task.FromResult(42); // Task<T> - асинхронная операция, возвращающая значения
        // используется как тип возвр значения у асинхронных методов

        //Console.WriteLine(1);
        //Console.WriteLine(1);
        //Console.WriteLine(1);
        //await Task.Delay(2000); // задержка в мейне продолжится
        //Console.WriteLine(1);
        //Console.WriteLine(1);
//    }

    //public async Task ExecuteParallelTasks()
    //{
    //    var task1 = Task.Delay(1000); // задержка 1 секунда
    //    var task2 = Task.Delay(2000); // 2 сек

    //    await Task.WhenAll(task1, task2); // Ожидание завершения обеих задач
    //    Console.WriteLine("Обе задачи завершены");
    //}

    //public async Task ExecuteParallelTasks()
    //{
    //    var task1 = Task.Delay(3000); // задержка 3 секунда
    //    var task2 = Task.Delay(1000); // 1 сек

    //    var completedTask = await Task.WhenAny(task1, task2); // Ожидание первой завершившийся задачи
    //    Console.WriteLine("Обе задачи завершены");
    //}

    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var db = new Database();

            var userTask = db.FindUserByNameAsync("Alice");
            Console.WriteLine("Ждем результат...");

            var user = await userTask;
            Console.WriteLine($"Пользователь найден: {user?.Name}");

            await db.ParallelQueriesAsync();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Database
    {
        private readonly List<User> users = new List<User>
   {
       new User { Id = 1, Name = "Alice", Age = 25 },
       new User { Id = 2, Name = "Bob", Age = 30 },
       new User { Id = 3, Name = "Charlie", Age = 35 }
   };

        public async Task<User> FindUserByNameAsync(string name)
        {
            Console.WriteLine("Начинаем асинхронный поиск пользователя...");
            await Task.Delay(2000); // Имитация задержки
            return users.FirstOrDefault(u => u.Name == name);
        }

        public async Task ParallelQueriesAsync()
        {
            var task1 = FindUserByNameAsync("Alice");
            var task2 = FindUserByNameAsync("Bob");

            await Task.WhenAll(task1, task2);

            var user1 = task1.Result;
            var user2 = task2.Result;

            Console.WriteLine($"Найдены пользователи: {user1?.Name}, {user2?.Name}");
        }
    }
