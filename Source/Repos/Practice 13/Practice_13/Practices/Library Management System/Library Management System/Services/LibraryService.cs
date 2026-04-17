using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public static class LibraryService
    {
        public static void BorrowBook(int memberId, int bookId)
        {
            int memberIndex = MemberService.FindIndexById(memberId);
            if (memberIndex == -1)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            int bookIndex = BookService.FindIndexById(bookId);
            if (bookIndex == -1)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (BookService.books[bookIndex].IsBorrowed)
            {
                Console.WriteLine("Book is already borrowed.");
                return;
            }

            BookService.books[bookIndex].IsBorrowed = true;
            BookService.books[bookIndex].BorrowedByMemberId = memberId;
            Console.WriteLine("Book borrowed successfully.");
        }

        public static void ReturnBook(int bookId)
        {
            int bookIndex = BookService.FindIndexById(bookId);
            if (bookIndex == -1)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!BookService.books[bookIndex].IsBorrowed)
            {
                Console.WriteLine("Book is not borrowed.");
                return;
            }

            BookService.books[bookIndex].IsBorrowed = false;
            BookService.books[bookIndex].BorrowedByMemberId = null;
            Console.WriteLine("Book returned successfully.");
        }
    }
}