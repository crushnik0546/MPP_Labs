using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicListGeneric
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public Book()
        {
            Author = "Undefined";
            Title = "Undefind";
            Year = 0;
        }

        public Book(string author, string title, int year)
        {
            Author = author;
            Title = title;
            Year = year;
        }

        public override string ToString()
        {
            return $"Author: {Author, -20} Title: {Title, -20} Year: {Year, -4}";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Book b = (Book)obj;
                return (Author == b.Author) && (Title == b.Title) && (Year == b.Year);
            }
        }
    }
}
