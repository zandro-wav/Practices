using LibraryManagementSystem.Services;

MemberService.Initialize();
BookService.Initialize();

while (true)
{
    Console.WriteLine("\n1 - Register Member");
    Console.WriteLine("2 - Show All Members");
    Console.WriteLine("3 - Update Member");
    Console.WriteLine("4 - Delete Member");
    Console.WriteLine("5 - Add Book");
    Console.WriteLine("6 - Show All Books");
    Console.WriteLine("7 - Update Book");
    Console.WriteLine("8 - Delete Book");
    Console.WriteLine("9 - Borrow Book");
    Console.WriteLine("10 - Return Book");
    Console.WriteLine("0 - Exit");
    Console.Write("\nChoose: ");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("FirstName: "); string fn = Console.ReadLine();
            Console.Write("LastName: "); string ln = Console.ReadLine();
            Console.Write("Age: "); int age = int.Parse(Console.ReadLine());
            Console.Write("Email: "); string em = Console.ReadLine();
            Console.Write("PersonalNumber: "); string pn = Console.ReadLine();
            MemberService.AddMember(fn, ln, age, em, pn);
            break;

        case "2":
            MemberService.GetAllMembers();
            break;

        case "3":
            MemberService.GetAllMembers();
            Console.Write("Enter Member ID to update: ");
            MemberService.UpdateMember(int.Parse(Console.ReadLine()));
            break;

        case "4":
            MemberService.GetAllMembers();
            Console.Write("Enter Member ID to delete: ");
            MemberService.DeleteMember(int.Parse(Console.ReadLine()));
            break;

        case "5":
            Console.Write("Title: "); string title = Console.ReadLine();
            Console.Write("Author: "); string author = Console.ReadLine();
            Console.Write("Genre: "); string genre = Console.ReadLine();
            Console.Write("PublishedYear: "); int year = int.Parse(Console.ReadLine());
            BookService.AddBook(title, author, genre, year);
            break;

        case "6":
            BookService.GetAllBooks();
            break;

        case "7":
            BookService.GetAllBooks();
            Console.Write("Enter Book ID to update: ");
            BookService.UpdateBook(int.Parse(Console.ReadLine()));
            break;

        case "8":
            BookService.GetAllBooks();
            Console.Write("Enter Book ID to delete: ");
            BookService.DeleteBook(int.Parse(Console.ReadLine()));
            break;

        case "9":
            MemberService.GetAllMembers();
            Console.Write("Enter Member ID: ");
            int memberId = int.Parse(Console.ReadLine());
            BookService.GetAllBooks();
            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());
            LibraryService.BorrowBook(memberId, bookId);
            break;

        case "10":
            BookService.GetAllBooks();
            Console.Write("Enter Book ID to return: ");
            LibraryService.ReturnBook(int.Parse(Console.ReadLine()));
            break;

        case "0":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
//formatting and clearing-up done by our dear broski Claudine :)
//Ft. Claude