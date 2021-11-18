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
                new Book("Jeffrey Richter", "Windows via C++", 2007),
                new Book("Sui Ishida", "Tokyo Ghoul", 2012),
                new Book("Andrzej Sapkowski", "The Last wish", 1993)
            };

            DynamicList<Book> bookList = new DynamicList<Book>(books);

            Console.WriteLine("BookList after initialization");
            PrintBooksWithoutEnumerator(bookList);

            
            bookList.Add(new Book("Jonathan Corbet", "Linux Device Driver", 2017));
            Console.WriteLine("\nBookList after aading 1 book");
            PrintBooksByEnumerator(bookList);

            bookList.Remove(new Book("Sui Ishida", "Tokyo Ghoul", 2012));
            bookList.Remove(new Book("Andrzej Sapkowski", "The Last wish", 1993));
            Console.WriteLine("\nBookList after delete 2 books (\"Sui Issida\", \"Tokyo Ghoul\", 2012) and (\"Andrzej Sapkowski\", \"The Last wish\", 1993)");
            PrintBooksByEnumerator(bookList);

            bookList.RemoveAt(0);
            Console.WriteLine("\nBookList after delete 1 book with index = 0 ");
            PrintBooksByEnumerator(bookList);

            bookList.Clear();
            Console.WriteLine("\nBookList after delete all books");
            PrintBooksByEnumerator(bookList);

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
