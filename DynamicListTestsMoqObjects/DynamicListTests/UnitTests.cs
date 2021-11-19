using NUnit.Framework;
using Moq;
using System.Collections;
using DynamicListGeneric;

namespace DynamicListTests
{
    public class Tests
    {
        private static Book[] books = new Book[]
        {
            new Book("Jeffrey Richter", "CLR via C#", 2018),
            new Book("Jeffrey Richter", "Windows via C++", 2001),
            new Book("Sui Ishida", "Tokyo Ghoul", 2012),
            new Book("Andrzej Sapkowski", "The Last wish", 1993)
        };

        private static int[] integerValues = new int[]
        {
            3, 7, 8, 8, 1, 0, 5, 101, 2
        };

        private static double[] doubleValues = new double[]
        {
            3.7, 1.7, 8.909, 23.562, 23.561, 0.7, -4.785, 101.90, 2.123
        };

        [Test]
        public void SortBooksByYear()
        {
            var moq = new Mock<IComparer>();
            moq.Setup(cmp => cmp.Compare(It.IsAny<object?>(), It.IsAny<object?>())).Returns((object? x, object? y) =>
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return 1;
                else if (y == null)
                    return -1;
                else
                    return ((Book)x).Year.CompareTo(((Book)y).Year);
            });
        
            DynamicList<Book> bookList = new DynamicList<Book>(books);
            bookList.Sort(moq.Object);

            Book[] expected = new Book[]
            {
                new Book("Andrzej Sapkowski", "The Last wish", 1993),
                new Book("Jeffrey Richter", "Windows via C++", 2001),
                new Book("Sui Ishida", "Tokyo Ghoul", 2012),
                new Book("Jeffrey Richter", "CLR via C#", 2018)
            };

            CollectionAssert.AreEqual(expected, bookList);
        }

        [Test]
        public void SortBooksByAuthor()
        {
            var moq = new Mock<IComparer>();
            moq.Setup(cmp => cmp.Compare(It.IsAny<object?>(), It.IsAny<object?>())).Returns((object? x, object? y) =>
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return 1;
                else if (y == null)
                    return -1;
                else
                    return ((Book)x).Author.CompareTo(((Book)y).Author);
            });

            DynamicList<Book> bookList = new DynamicList<Book>(books);
            bookList.Sort(moq.Object);

            Book[] expected = new Book[]
            {
                new Book("Andrzej Sapkowski", "The Last wish", 1993),
                new Book("Jeffrey Richter", "CLR via C#", 2018),
                new Book("Jeffrey Richter", "Windows via C++", 2001),
                new Book("Sui Ishida", "Tokyo Ghoul", 2012)
            };

            CollectionAssert.AreEqual(expected, bookList);
        }

        [Test]
        public void SortBooksByTitle()
        {
            var moq = new Mock<IComparer>();
            moq.Setup(cmp => cmp.Compare(It.IsAny<object?>(), It.IsAny<object?>())).Returns((object? x, object? y) =>
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return 1;
                else if (y == null)
                    return -1;
                else
                    return ((Book)x).Title.CompareTo(((Book)y).Title);
            });

            DynamicList<Book> bookList = new DynamicList<Book>(books);
            bookList.Sort(moq.Object);

            Book[] expected = new Book[]
            {
                new Book("Jeffrey Richter", "CLR via C#", 2018),
                new Book("Andrzej Sapkowski", "The Last wish", 1993),
                new Book("Sui Ishida", "Tokyo Ghoul", 2012),
                new Book("Jeffrey Richter", "Windows via C++", 2001)
            };

            CollectionAssert.AreEqual(expected, bookList);
        }

        [Test]
        public void AddItemsAndSortIntegerValues()
        {
            var moq = new Mock<IComparer>();
            moq.Setup(cmp => cmp.Compare(It.IsAny<object?>(), It.IsAny<object?>())).Returns((object? x, object? y) =>
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return 1;
                else if (y == null)
                    return -1;
                else
                    return ((int)x).CompareTo((int)y);
            });

            DynamicList<int> integers = new DynamicList<int>(integerValues);
            integers.Add(-45);
            integers.Sort(moq.Object);

            int[] expected = new int[]
            {
                -45, 0, 1, 2, 3, 5, 7, 8, 8, 101
            };

            CollectionAssert.AreEqual(expected, integers);
        }

        [Test]
        public void RemoveItemsAndSortDoubleValues()
        {
            var moq = new Mock<IComparer>();
            moq.Setup(cmp => cmp.Compare(It.IsAny<object?>(), It.IsAny<object?>())).Returns((object? x, object? y) =>
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return 1;
                else if (y == null)
                    return -1;
                else
                    return ((double)x).CompareTo((double)y);
            });

            DynamicList<double> doubles = new DynamicList<double>(doubleValues);
            doubles.Remove(0.7);
            doubles.Remove(1.7);
            doubles.Remove(8.909);
            doubles.Remove(23.562);

            doubles.Sort(moq.Object);

            double[] expected = new double[]
            {
                -4.785, 2.123, 3.7, 23.561, 101.90
            };

            CollectionAssert.AreEqual(expected, doubles);
        }

        [Test]
        public void RemoveAtItemsIntegerValues()
        {
            DynamicList<int> integers = new DynamicList<int>(integerValues);
            integers.RemoveAt(2);
            integers.RemoveAt(2);

            int[] expected = new int[]
            {
                3, 7, 1, 0, 5, 101, 2
            };

            CollectionAssert.AreEqual(expected, integers);
        }

        [Test]
        public void ClearItemsIntegerValues()
        {
            DynamicList<int> integers = new DynamicList<int>(integerValues);
            integers.Clear();

            int[] expected = new int[0];

            CollectionAssert.AreEqual(expected, integers);
        }
    }
}