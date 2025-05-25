using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class Program
{
    static void ColorLine()
    {
        Console.WriteLine();
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('*', 120));
        Console.ForegroundColor = originalColor;
    }

    static void Main()
    {
        string filename = "C:\\Users\\vital\\source\\repos\\booksCSVfile\\booksCSVfile\\books.csv.txt";
        List<List<string>> books = GetBooks(filename);

        ColorLine();
        foreach (var book in books)
        {
            var output = new List<string>();
            for (int i = 0; i < book.Count - 2; i++)
            {
                output.Add($"'{book[i]}'");
            }
            output.AddRange(book.GetRange(book.Count - 2, 2));

            Console.WriteLine(string.Join(", ", output));
        }
        ColorLine();



        Console.Write("Введите подстроку для фильтрации: ");
        string substring = Console.ReadLine();
        Console.WriteLine();
        var filteredBooks = FilteredBooks(books, substring);

        foreach (var book in filteredBooks)
        {
            var output = new List<string>();
            for (int i = 0; i < book.Count - 2; i++)
            {
                output.Add($"'{book[i]}'");
            }
            output.AddRange(book.GetRange(book.Count - 2, 2));

            Console.WriteLine(string.Join(", ", output));
        }
        ColorLine();



        var pricesList = CalculateTotalPrices(filteredBooks); 

        foreach (var item in pricesList)
        {
            Console.WriteLine($"('{item.isbn}', {item.totalPrice})");
        }
        ColorLine();
    }

    static List<List<string>> GetBooks(string filename)
    {
        List<List<string>> books = new List<List<string>>();

        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] row = line.Split('|');

                if (row.Length == 5)
                {
                    List<string> book = new List<string>
                    {
                        row[0], // ISBN
                        row[1], // Title
                        row[2], // Author
                        row[3], // Qua  ntity
                        row[4]  // Price
                    };
                    books.Add(book);
                }
            }
        }
        return books;
    }

    static List<List<string>> FilteredBooks(List<List<string>> books, string substring)
    {
        List<List<string>> filteredBooks = new List<List<string>>();

        foreach (var book in books)
        {
            if (book.Count >= 3 && book[1].IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                filteredBooks.Add(book);
            }
        }

        return filteredBooks;
    }

    static List<(string isbn, double totalPrice)> CalculateTotalPrices(List<List<string>> filteredBooks)
    {
        List<(string isbn, double totalPrice)> result = new List<(string isbn, double totalPrice)>();

        foreach (var book in filteredBooks)
        {
            string isbn = book[0];              
            bool isValidQty = int.TryParse(book[3], out int quantity);       
            bool isValidPrice = double.TryParse(book[4], NumberStyles.Any, CultureInfo.InvariantCulture, out double price); // Безопасное преобразование цены

            if (isValidQty && isValidPrice)
            {
                double totalPrice = quantity * price;
                result.Add((isbn, totalPrice));
            }
            else
            {
                Console.WriteLine($"Неверный формат данных в книге: {string.Join(",", book)}");
            }
        }
        return result;
    }

}