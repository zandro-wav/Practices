using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

    public class Book
    {
        public int Id;
        public string Title;
        public string Author;
        public string Genre;
        public int PublishedYear;
        public bool IsBorrowed;
        public int? BorrowedByMemberId;

        public void PrintInfo()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("PublishedYear: " + PublishedYear);
            Console.WriteLine("IsBorrowed: " + IsBorrowed);
            Console.WriteLine("BorrowedBy: " + (BorrowedByMemberId.HasValue ? BorrowedByMemberId.ToString() : "N/A"));
            Console.WriteLine("------------------------");
        }
}