public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }
    public int[] Grades { get; set; }

    public Student(string firstName, string lastName, string group, int[] grades)
    {
        FirstName = firstName;
        LastName = lastName;
        Group = group;
        Grades = grades;
    }
}

class Students
{
    static void Main(string[] args)
    {
        var students = GenerateStudents();

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Найти студентов с средней оценкой выше 4");
            Console.WriteLine("2. Отсортировать студентов по фамилии и имени");
            Console.WriteLine("3. Получить список имён студентов с хотя бы одной оценкой 5");
            Console.WriteLine("4. Сгруппировать студентов по группам и вычислить среднюю оценку");
            Console.WriteLine("5. Найти студентов из определенной группы с средней оценкой выше 4");
            Console.WriteLine("6. Выход");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FindStudentsWithAverageGradeAbove4(students);
                    break;
                case "2":
                    SortStudentsByLastNameAndFirstName(students);
                    break;
                case "3":
                    GetStudentsWithAtLeastOneGrade5(students);
                    break;
                case "4":
                    GroupStudentsByGroupAndCalculateAverageGrade(students);
                    break;
                case "5":
                    FindStudentsFromSpecificGroupWithAverageGradeAbove4(students);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неправильный выбор.");
                    break;
            }
        }
    }

    static List<Student> GenerateStudents()
    {
        var students = new List<Student>
    {
        new Student("Иван", "Иванов", "Группа1", new int[] { 5, 4, 5, 4, 5 }),
        new Student("Петр", "Петров", "Группа1", new int[] { 4, 5, 4, 5, 4 }),
        new Student("Сергей", "Сергеев", "Группа2", new int[] { 5, 5, 5, 5, 5 }),
        new Student("Алексей", "Алексеев", "Группа2", new int[] { 4, 4, 4, 4, 4 }),
        new Student("Дмитрий", "Дмитриев", "Группа3", new int[] { 5, 4, 5, 4, 5 }),
        new Student("Николай", "Николаев", "Группа3", new int[] { 4, 5, 4, 5, 4 }),
        new Student("Владимир", "Владимиров", "Группа4", new int[] { 5, 5, 5, 5, 5 }),
        new Student("Андрей", "Андреев", "Группа4", new int[] { 4, 4, 4, 4, 4 }),
        new Student("Михаил", "Михайлов", "Группа5", new int[] { 5, 4, 5, 4, 5 }),
        new Student("Олег", "Олегов", "Группа5", new int[] { 4, 5, 4, 5, 4 }),
        new Student("Юрий", "Юрьев", "Группа1", new int[] { 5, 5, 5, 5, 5 }),
        new Student("Виктор", "Викторов", "Группа2", new int[] { 4, 4, 4, 4, 4 }),
        new Student("Анатолий", "Анатольев", "Группа3", new int[] { 5, 4, 5, 4, 5 }),
        new Student("Геннадий", "Геннадиев", "Группа4", new int[] { 4, 5, 4, 5, 4 }),
        new Student("Валентин", "Валентинов", "Группа5", new int[] { 5, 5, 5, 5, 5 }),
    };

        return students;
    }

    static void FindStudentsWithAverageGradeAbove4(List<Student> students)
    {
        var studentsWithAverageGradeAbove4 = students.Where(s => s.Grades.Average() > 4);

        foreach (var student in studentsWithAverageGradeAbove4)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }

    static void SortStudentsByLastNameAndFirstName(List<Student> students)
    {
        var sortedStudents = students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }

    static void GetStudentsWithAtLeastOneGrade5(List<Student> students)
    {
        var studentsWithAtLeastOneGrade5 = students.Where(s => s.Grades.Contains(5));

        foreach (var student in studentsWithAtLeastOneGrade5)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }

    static void GroupStudentsByGroupAndCalculateAverageGrade(List<Student> students)
    {
        var groupedStudents = students.GroupBy(s => s.Group);

        foreach (var group in groupedStudents)
        {
            var averageGrade = group.SelectMany(s => s.Grades).Average();

            Console.WriteLine($"Группа {group.Key}: {averageGrade}");
        }
    }

    static void FindStudentsFromSpecificGroupWithAverageGradeAbove4(List<Student> students)
    {
        Console.Write("Введите номер группы: ");
        var groupNumber = int.Parse(Console.ReadLine());

        var studentsFromGroup = students.Where(s => s.Group == $"Группа{groupNumber}");

        var studentsWithAverageGradeAbove4 = studentsFromGroup.Where(s => s.Grades.Average() > 4);

        foreach (var student in studentsWithAverageGradeAbove4)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}