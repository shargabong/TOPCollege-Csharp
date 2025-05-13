using Microsoft.EntityFrameworkCore;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Навигационное свойство
    public List<Product> Products2 { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Внешний ключ
    public int CategoryId { get; set; }

    // Навигационное свойство
    public Category Category { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string Date { get; set; }
    public int CustomerId { get; set; }
    public string Status { get; set; }

    // Навигационное свойство к Customer
    public Customer Customer { get; set; }

    // Навигационное свойство к OrderDetails (заказ может иметь много деталей)
    public List<OrderDetail> OrderDetails { get; set; }
}

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }     // Внешний ключ
    public int ProductId { get; set; }   // Внешний ключ
    public int Quantity { get; set; }

    // Навигационное свойство к заказу
    public Order Order { get; set; }

    // Навигационное свойство к продукту
    public Product Product { get; set; }

}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    // Навигационное свойство к заказам этого клиента
    public List<Order> Orders { get; set; }


}

public class ShopDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products2 { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=123");
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Связь: Category (1) - Product (M) ---
            // У одной Категории много Продуктов.
            // У одного Продукта одна Категория.
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)          // У Product есть одна Category
                .WithMany(c => c.Products2)        // У Category есть много Products
                .HasForeignKey(p => p.CategoryId); // Внешний ключ в Product - это CategoryId

            // --- Связь: Customer (1) - Order (M) ---
            // У одного Клиента много Заказов.
            // У одного Заказа один Клиент.
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)          // У Order есть один Customer
                .WithMany(c => c.Orders)          // У Customer есть много Orders
                .HasForeignKey(o => o.CustomerId); // Внешний ключ в Order - это CustomerId

            // --- Связь: Order (1) - OrderDetail (M) ---
            // У одного Заказа много Деталей Заказа.
            // У одной Детали Заказа один Заказ.
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)           // У OrderDetail есть один Order
                .WithMany(o => o.OrderDetails)    // У Order есть много OrderDetails
                .HasForeignKey(od => od.OrderId);  // Внешний ключ в OrderDetail - это OrderId

            // --- Связь: Product (1) - OrderDetail (M) ---
            // Один Продукт может быть во многих Деталях Заказа.
            // Одна Деталь Заказа ссылается на один Продукт.
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)         // У OrderDetail есть один Product
                .WithMany(p => p.OrderDetails)    // У Product есть много OrderDetails
                .HasForeignKey(od => od.ProductId); // Внешний ключ в OrderDetail - это ProductId
        }
    }
}

class electronic
{
    static void AddTestData(ShopDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { Name = "Электроника" },
                new Category { Name = "Бытовая техника" }
            );
            context.SaveChanges();
        }

        if (!context.Products2.Any())
        {
            context.Products2.AddRange(
                new Product { Name = "Ноутбук", Price = 40000, CategoryId = 1 },
                new Product { Name = "Холодильник", Price = 30000, CategoryId = 2 },
                new Product { Name = "Смартфон", Price = 20000, CategoryId = 1 }
            );
            context.SaveChanges();
        }
    }

    static void Main()
    {
        var context = new ShopDbContext();


        // Проверка наличия таблиц
        context.Database.EnsureCreated();

        // Добавление тестовых данных
        AddTestData(context);

        // Получение всех продуктов с категориями
        Console.WriteLine("Все продукты с категориями:");
        var productsWithCategories = context.Products2
            .Include(p => p.Category)
            .ToList();

        foreach (var product in productsWithCategories)
        {
            Console.WriteLine($"{product.Name} - {product.Price} руб. (Категория: {product.Category?.Name})");
        }

        // Поиск продуктов по категории
        Console.WriteLine("\nПродукты в категории 'Электроника':");
        var categoryId = context.Categories
            .Where(c => c.Name == "Электроника")
            .Select(c => c.Id)
            .FirstOrDefault();

        var electronicsProducts = context.Products2
            .Where(p => p.CategoryId == categoryId)
            .ToList();

        foreach (var product in electronicsProducts)
        {
            Console.WriteLine($"{product.Name} - {product.Price} руб.");
        }

        // Добавление нового продукта
        Console.WriteLine("\nДобавление нового продукта:");
        var newCategory = context.Categories.FirstOrDefault(c => c.Name == "Электроника");
        if (newCategory != null)
        {
            context.Products2.Add(new Product
            {
                Name = "Новый ноутбук",
                Price = 50000,
                CategoryId = newCategory.Id
            });
            context.SaveChanges();
            Console.WriteLine("Новый продукт добавлен.");
        }

        // Удаление продукта
        Console.WriteLine("\nУдаление продукта:");
        var productToRemove = context.Products2.FirstOrDefault(p => p.Name == "Новый ноутбук");
        if (productToRemove != null)
        {
            context.Products2.Remove(productToRemove);
            context.SaveChanges();
            Console.WriteLine("Продукт удален.");
        }
    }
}