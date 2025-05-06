using Microsoft.EntityFrameworkCore;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public double Pages { get; set; }
    public int Price { get; set; }
    public bool IsAvailable { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=(local);Database=Books;Trusted_Connection=True;");
    }
}

class Database2
{
    static void Main()
    {
        var context = new AppDbContext();

        context.Database.EnsureCreated();

        context.Books.AddRange(
            new Book
            {
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Genre = "Fiction",
                PublicationYear = 1925,
                Pages = 180,
                IsAvailable = true,
                Rating = 4.5,
                Description = "A classic novel about the American Dream and the decadence of the 1920s."
            },

            new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Genre = "Fiction",
                PublicationYear = 1960,
                Pages = 281,
                IsAvailable = true,
                Rating = 4.3,
                Description = "A classic novel about racial injustice and the struggles of a young girl in the South."
            },

            new Book
            {
                Title = "1984",
                Author = "George Orwell",
                Genre = "Dystopian",
                PublicationYear = 1949,
                Pages = 328,
                IsAvailable = true,
                Rating = 4.2,
                Description = "A dystopian novel about a totalitarian society controlled by Big Brother."
            },

            new Book
            {
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Genre = "Romance",
                PublicationYear = 1813,
                Pages = 279,
                IsAvailable = true,
                Rating = 4.4,
                Description = "A classic novel about the love between Elizabeth Bennet and Mr. Darcy."
            },

            new Book
            {
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                Genre = "Fantasy",
                PublicationYear = 1937,
                Pages = 310,
                IsAvailable = true,
                Rating = 4.7,
                Description = "A classic novel about a hobbit named Bilbo Baggins and his quest to destroy the One Ring."
            }
                );

        context.SaveChanges();

        Console.WriteLine("Таблица создана или обновлена");

        int a = 0;

        while (a == 0)
        {
            Console.WriteLine("Список всех книг:\n");
            var books = context.Books.ToList();

            foreach (var b in books)
            {
                Console.WriteLine($"{b.Id}. {b.Title} - {b.Author},\n" +
                    $"Дата публикации: {b.PublicationYear}, страниц: {b.Pages}, цена:" +
                    $"{b.Price}, доступность: {b.IsAvailable}, рейтинг: {b.Rating}\n" +
                    $"Краткое описание: {b.Description}");
            }

            Console.WriteLine("\nВыберите дейтсвие:\n" +
                "1 - Добавить книгу\n" +
                "2 - Обновление информации о книге\n" +
                "3 - Удаление книги\n" +
                "4 - Поиск книги по жанру\n" +
                "5 - Поиск кинги по году\n" +
                "6 - Поиск книги по году публикации\n" +
                "7 - Найти все книги до (n) цены\n" +
                "8 - Поиск по ключевым словам в описании книги\n" +
                "9 - Вычислить средний рейтинг книг по выбранному жанру\n" +
                "10 - Общее кол-во страниц всех книг\n" +
                "11 - Найти самую дорогую и самую дешевую книгу\n" +
                "12 - Выход\n");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Введите Автора");
                    string choice1 = Console.ReadLine();
                    Console.WriteLine("Введите название");
                    string choice2 = Console.ReadLine();
                    Console.WriteLine("Введите жанр");
                    string choice3 = Console.ReadLine();
                    Console.WriteLine("Введите год публикации");
                    int choice4 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите кол-во страниц");
                    int choice5 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите цену");
                    int choice6 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите доступность (true/false)");
                    bool choice7 = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Введите рейтинг");
                    double choice8 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите описание");
                    string choice9 = Console.ReadLine();

                    context.Books.AddRange(
                        new Book
                        {
                            Author = choice1,
                            Title = choice2,
                            Genre = choice3,
                            PublicationYear = choice4,
                            Pages = choice5,
                            Price = choice6,
                            IsAvailable = choice7,
                            Rating = choice8,
                            Description = choice9
                        }
                        );

                    Console.WriteLine("Книга добавлена, нажмите любую кнопку");
                    context.SaveChanges();
                    break;

                case 2:
                    Console.Write("\nВведите id книги: ");
                    int cho = int.Parse(Console.ReadLine());
                    var book = context.Books.Find(cho);

                    Console.Write("\nВведите что хотите поменять (Тут мы должны были спросить что хотим поменять \" + " +
                        "меняем только название, потому что получается огромное древо if-a): ");
                    string cho1 = Console.ReadLine();

                    if (book != null)
                    {
                        book.Title = cho1;

                        context.SaveChanges();
                        Console.WriteLine($"Название книги изменено на {book.Title} обновлена до {cho1}");
                    }
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;

                case 7:
                    break;

                case 8:
                    break;

                case 9:
                    break;

                case 10:
                    break;

                case 11:
                    break;

                case 12:
                    a = int.Parse(Console.ReadLine());
                    break;


            }

            // Чтобы айди не добавлялся поверх с каждым запуском
            context.Database.ExecuteSqlRaw(@"TRUNCATE TABLE ""Books"" RESTART IDENTITY;");

        }
    }
}