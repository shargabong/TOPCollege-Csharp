using Dapper;
using Npgsql;

public class User
{
    public int UserId { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"ID: {UserId}, Login: {Login}, Name: {FullName}, Role: {Role}, Blocked: {IsBlocked}, Created: {CreatedAt}";

    }
}

public class Account
{
    public int AccountId { get; set; }
    public int UserId { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"ID: {AccountId}, UserID: {UserId}, Number: {AccountNumber}, Balance: {Balance} {Currency}, Created: {CreatedAt}";
    }
}


public class Program
{
    private const string ConnectionString = "Host=localhost;Database=ATM;Username=postgres;Password=zxc;";

    static void Main(string[] args)
    {
        Console.WriteLine("Демонстрация интеграции с БД PostgreSQL");

        TestConnection();

        var newUser = new User
        {
            Login = "testuser" + DateTime.Now.Ticks,
            PasswordHash = "hashed_password_example",
            FullName = "Тестовый Пользователь",
            Role = "client"
        };
        int newUserId = AddUser(newUser);
        Console.WriteLine($"\nДобавлен новый пользователь с ID: {newUserId}");
        newUser.UserId = newUserId;

        User fetchedUser = GetUserById(newUserId);
        if (fetchedUser != null)
        {
            Console.WriteLine($"\nПолучен пользователь: {fetchedUser}");
        }

        Console.WriteLine("\nВсе пользователи:");
        List<User> allUsers = GetAllUsers();
        foreach (var user in allUsers)
        {
            Console.WriteLine(user);
        }

        if (fetchedUser != null)
        {
            fetchedUser.FullName = "Тестовый Пользователь (Обновлен)";
            fetchedUser.IsBlocked = true;
            UpdateUser(fetchedUser);
            Console.WriteLine($"\nПользователь {fetchedUser.UserId} обновлен.");
            User updatedUser = GetUserById(fetchedUser.UserId);
            Console.WriteLine($"Проверка обновления: {updatedUser}");
        }

        DeleteUser(newUserId);
        Console.WriteLine($"\nПользователь с ID {newUserId} удален.");
        User deletedUser = GetUserById(newUserId);
        Console.WriteLine(deletedUser == null ? "Пользователь успешно удален из БД." : "Ошибка: пользователь все еще существует.");


        Console.WriteLine("\n--- Демонстрация работы со счетами ---");

        User ivanov = allUsers.FirstOrDefault(u => u.Login == "ivanov");
        if (ivanov != null)
        {
            var newAccount = new Account
            {
                UserId = ivanov.UserId,
                AccountNumber = "40800000" + DateTime.Now.Ticks.ToString().Substring(8),
                Balance = 1000.00m,
                Currency = "RUB"
            };
            int newAccountId = AddAccount(newAccount);
            Console.WriteLine($"Добавлен новый счет с ID: {newAccountId} для пользователя {ivanov.Login}");

            List<Account> ivanovAccounts = GetAccountsByUserId(ivanov.UserId);
            Console.WriteLine($"Счета пользователя {ivanov.Login}:");
            foreach (var acc in ivanovAccounts)
            {
                Console.WriteLine(acc);
            }
        }
        else
        {
            Console.WriteLine("Пользователь 'ivanov' не найден для демонстрации работы со счетами.");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    public static void TestConnection()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Соединение с PostgreSQL успешно установлено!");
                var version = connection.ExecuteScalar<string>("SELECT version();");
                Console.WriteLine($"Версия PostgreSQL: {version}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка подключения: {ex.Message}");
        }
    }


    public static int AddUser(User user)
    {
        string sql = @"
            INSERT INTO users (login, password_hash, full_name, role, is_blocked, created_at)
            VALUES (@Login, @PasswordHash, @FullName, @Role, @IsBlocked, @CreatedAt)
            RETURNING user_id;";

        using (var connection = new NpgsqlConnection(ConnectionString))
        {

            if (user.CreatedAt == DateTime.MinValue) user.CreatedAt = DateTime.UtcNow;

            int id = connection.ExecuteScalar<int>(sql, user);
            return id;
        }
    }

    public static User GetUserById(int userId)
    {
        string sql = "SELECT user_id AS UserId, login, password_hash AS PasswordHash, full_name AS FullName, role, is_blocked AS IsBlocked, created_at AS CreatedAt FROM users WHERE user_id = @UserId;";
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            return connection.QueryFirstOrDefault<User>(sql, new { UserId = userId });
        }
    }

    public static List<User> GetAllUsers()
    {
        string sql = "SELECT user_id AS UserId, login, password_hash AS PasswordHash, full_name AS FullName, role, is_blocked AS IsBlocked, created_at AS CreatedAt FROM users;";
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            return connection.Query<User>(sql).ToList();
        }
    }

    public static void UpdateUser(User user)
    {
        string sql = @"
            UPDATE users
            SET login = @Login,
                password_hash = @PasswordHash,
                full_name = @FullName,
                role = @Role,
                is_blocked = @IsBlocked
            WHERE user_id = @UserId;";
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Execute(sql, user);
        }
    }

    public static void DeleteUser(int userId)
    {

        string sql = "DELETE FROM users WHERE user_id = @UserId;";
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            connection.Execute(sql, new { UserId = userId });
        }
    }
    public static int AddAccount(Account account)
    {
        string sql = @"
            INSERT INTO accounts (user_id, account_number, balance, currency, created_at)
            VALUES (@UserId, @AccountNumber, @Balance, @Currency, @CreatedAt)
            RETURNING account_id;";
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            if (account.CreatedAt == DateTime.MinValue) account.CreatedAt = DateTime.UtcNow;
            int id = connection.ExecuteScalar<int>(sql, account);
            return id;
        }
    }

    public static List<Account> GetAccountsByUserId(int userId)
    {
        string sql = "SELECT account_id AS AccountId, user_id AS UserId, account_number AS AccountNumber, balance, currency, created_at AS CreatedAt FROM accounts WHERE user_id = @UserId;";
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            return connection.Query<Account>(sql, new { UserId = userId }).ToList();
        }
    }
}