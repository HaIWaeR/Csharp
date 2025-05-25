using System;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }


    public Book(string title, string author, int year, string isbn)
    {
        Title = title;
        Author = author;
        Year = year;
        ISBN = isbn;
    }

    public override string ToString()
    {
        return $"Название: {Title}, Автор: {Author}, Год: {Year}, ISBN: {ISBN}";
    }
}