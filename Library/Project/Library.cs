using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Library
{
    private List<Book> books;
    private const string FilePath = "library_data.json";

    public Library()
    {
        books = new List<Book>();
        LoadBooks();
    }

    // добвление книги 
    public void AddBook(Book book)
    {
        books.Add(book);
        SaveBooks();
    }


    // Удаление книги 
    public bool RemoveBook(string isbn)
    {
        var book = books.FirstOrDefault(b => b.ISBN == isbn);
        if (book != null)
        {
            books.Remove(book);
            SaveBooks();
            return true;
        }
        return false;
    }

    public List<Book> FindBooksByTitle(string title)
    {
        return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }


    // Вывод всех книг
    public void DisplayAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("В библиотеке нет книг.");
            return;
        }


        Console.Clear();
        Console.WriteLine("Список всех книг:");
        foreach (var book in books)
        {
            Console.WriteLine($"\n{book}");
        }
        Console.ReadLine();
        Console.Clear();
    }


    private void SaveBooks()
    {
        try
        {
            var json = System.Text.Json.JsonSerializer.Serialize(books);
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
        }
    }

    private void LoadBooks()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                books = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
        }


    
    }
}