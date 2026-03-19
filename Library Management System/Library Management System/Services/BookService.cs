using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public static class BookService
    {
        public static Book[] books = new Book[100];
        private static int count = 0;
        private static int nextId = 11;

        public static void Initialize()
        {
            Book[] initialBooks = new Book[10]
            {
                new Book { Id = 1,  Title = "Clean Code",               Author = "Robert Martin",  Genre = "Programming",    PublishedYear = 2008 },
                new Book { Id = 2,  Title = "The Pragmatic Programmer",  Author = "Andrew Hunt",    Genre = "Programming",    PublishedYear = 1999 },
                new Book { Id = 3,  Title = "Design Patterns",           Author = "Erich Gamma",    Genre = "Programming",    PublishedYear = 1994 },
                new Book { Id = 4,  Title = "The Hobbit",                Author = "J.R.R. Tolkien", Genre = "Fantasy",        PublishedYear = 1937 },
                new Book { Id = 5,  Title = "1984",                      Author = "George Orwell",  Genre = "Dystopian",      PublishedYear = 1949 },
                new Book { Id = 6,  Title = "Atomic Habits",             Author = "James Clear",    Genre = "Self Development",PublishedYear = 2018 },
                new Book { Id = 7,  Title = "Deep Work",                 Author = "Cal Newport",    Genre = "Productivity",   PublishedYear = 2016 },
                new Book { Id = 8,  Title = "Rich Dad Poor Dad",         Author = "Robert Kiyosaki",Genre = "Finance",        PublishedYear = 1997 },
                new Book { Id = 9,  Title = "The Alchemist",             Author = "Paulo Coelho",   Genre = "Novel",          PublishedYear = 1988 },
                new Book { Id = 10, Title = "To Kill a Mockingbird",     Author = "Harper Lee",     Genre = "Classic",        PublishedYear = 1960 },
            };

            for (int i = 0; i < 10; i++) books[i] = initialBooks[i];
            count = 10;
        }

        public static void AddBook(string title, string author, string genre, int publishedYear)
        {
            books[count] = new Book
            {
                Id = nextId++,
                Title = title,
                Author = author,
                Genre = genre,
                PublishedYear = publishedYear
            };
            count++;
            Console.WriteLine("Book added successfully.");
        }

        public static void GetAllBooks()
        {
            if (count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                books[i].PrintInfo();
            }
        }

        public static void UpdateBook(int id)
        {
            int index = FindIndexById(id);
            if (index == -1)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.Write("New Title: ");
            books[index].Title = Console.ReadLine();

            Console.Write("New Author: ");
            books[index].Author = Console.ReadLine();

            Console.Write("New Genre: ");
            books[index].Genre = Console.ReadLine();

            Console.Write("New PublishedYear: ");
            books[index].PublishedYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Book updated successfully.");
        }

        public static void DeleteBook(int id)
        {
            int index = FindIndexById(id);
            if (index == -1)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                books[i] = books[i + 1];
            }
            books[count - 1] = null;
            count--;
            Console.WriteLine("Book deleted successfully.");
        }

        public static int FindIndexById(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i].Id == id) return i;
            }
            return -1;
        }
    }
}