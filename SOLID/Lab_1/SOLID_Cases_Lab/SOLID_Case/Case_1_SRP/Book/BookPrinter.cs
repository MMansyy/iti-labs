using System;

public class BookPrinter
{
    Book book;
    public BookPrinter(Book book)
    {
        this.book = book;
    }

    public void Print()
    {
        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
    }

}