using System;

namespace DynamicListGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book("Jeffrey Richter", "CLR via C#", 2018),
                new Book("Jeffrey Richter", "Windows via C++", 2001),
                new Book("Sui Ishida", "Tokyo Ghoul", 2012),
                new Book("Andrzej Sapkowski", "The Last wish", 1993)
            };

            DynamicList<Book> bookList = new DynamicList<Book>(books);

            Console.WriteLine("BookList after initialization");
            PrintBooksWithoutEnumerator(bookList);

            BookComparer cmp = new BookComparer();
            Console.WriteLine("BookList after sort");
            bookList.Sort(cmp);
            PrintBooksWithoutEnumerator(bookList);
        }

        static void PrintBooksWithoutEnumerator(DynamicList<Book> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i].ToString());
            }
        }

        static void PrintBooksByEnumerator(DynamicList<Book> books)
        {
            foreach(var item in books)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

}
