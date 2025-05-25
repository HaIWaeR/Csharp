using System;

class Program
{
    static void Main()
    {
        Library library = new Library();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("   Меню Библиотеки:\n");
            Console.WriteLine("1. Добавить новую книгу");
            Console.WriteLine("2. Удалить книгу по ISBN");
            Console.WriteLine("3. Найти книгу по названию");
            Console.WriteLine("4. Показать список всех книг");
            Console.WriteLine("5. Покинуть библиотеку");
            Console.Write("Выберите действие: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddNewBook(library); break;
                case "2": RemoveBookByISBN(library); break;
                case "3": FindBooksByTitle(library); break;
                case "4": library.DisplayAllBooks(); break;
                case "5": isRunning = false; break;
                default: 
                    Console.Clear();
                break;
            }
        }
    }

    static void AddNewBook(Library library)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Вы выбрали добавить новую книгу\n");
            Console.Write("Введите название книги: ");
            string? title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым");

            Console.Clear();
            Console.WriteLine("Вы выбрали добавить новую книгу\n");
            Console.Write("Введите автора книги: ");
            string? author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Автор не может быть пустым");

            Console.Clear();
            Console.WriteLine("Вы выбрали добавить новую книгу\n");
            Console.Write("Введите год издания: ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year <= 0)
                throw new ArgumentException("Неверный формат года");

            Console.Clear();
            Console.WriteLine("Вы выбрали добавить новую книгу\n");
            Console.Write("Введите ISBN: ");
            string? isbn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN не может быть пустым");

            Console.Clear();
            Console.WriteLine("Вы выбрали добавить новую книгу\n");
            Book newBook = new Book(title!, author!, year, isbn!);
            library.AddBook(newBook);
            Console.WriteLine("Книга успешно добавлена!");
            Console.ReadLine();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void RemoveBookByISBN(Library library)
    {
        Console.Clear();
        Console.WriteLine("Вы выбрали удалить книгу\n");
        Console.Write("Введите ISBN книги для удаления: ");
        string? isbn = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(isbn) && library.RemoveBook(isbn))
        {
            Console.Clear();
            Console.WriteLine("Вы выбрали удалить книгу\n");
            Console.WriteLine("Книга успешно удалена!");
            Console.ReadLine();
            Console.Clear();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Вы выбрали удалить книгу\n");
            Console.WriteLine("Книга с указанным ISBN не найдена или введен пустой ISBN.");
            Console.ReadLine();
            Console.Clear();
        }
    }

    static void FindBooksByTitle(Library library)
    {
        Console.Clear();
        Console.WriteLine("Вы выбрали найти книгу\n");
        Console.Write("Введите название или часть названия для поиска: ");
        string? title = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(title))
        {
            var foundBooks = library.FindBooksByTitle(title);
            if (foundBooks.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали найти книгу\n");
                Console.WriteLine("Найденные книги:");
                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"\n{book}");
                }
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали найти книгу\n");
                Console.WriteLine("Книги с таким названием не найдены.");
                Console.ReadLine();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine("Введено пустое название для поиска.");
        }
    }
}