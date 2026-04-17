using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryManagementSystem.Services
{
    public static class MemberService
    {
        public static Member[] members = new Member[100];
        private static int count = 0;
        private static int nextId = 1;

        public static void Initialize()
        {
            AddMember("Giorgi", "Beridze", 30, "giorgi@gmail.com", "01001234567");
        }

        public static void AddMember(string firstName, string lastName, int age, string email, string personalNumber)
        {
            members[count] = new Member
            {
                Id = nextId++,
                FirstName = firstName,
                LastName = lastName,
                Age = age.ToString(),
                Email = email,
                PersonalNumber = personalNumber,
                CreatedOn = DateTime.Now
            };
            count++;
            Console.WriteLine("Member added successfully.");
        }

        public static void GetAllMembers()
        {
            if (count == 0)
            {
                Console.WriteLine("No members found.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                members[i].PrintInfo();
            }
        }

        public static void UpdateMember(int id)
        {
            int index = FindIndexById(id);
            if (index == -1)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.Write("New FirstName: ");
            members[index].FirstName = Console.ReadLine();

            Console.Write("New LastName: ");
            members[index].LastName = Console.ReadLine();

            Console.Write("New Age: ");
            // fixed: Member.Age is a string, so assign the input string directly
            members[index].Age = Console.ReadLine();

            Console.Write("New Email: ");
            members[index].Email = Console.ReadLine();

            Console.Write("New PersonalNumber: ");
            members[index].PersonalNumber = Console.ReadLine();

            Console.WriteLine("Member updated successfully.");
        }

        public static void DeleteMember(int id)
        {
            int index = FindIndexById(id);
            if (index == -1)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                members[i] = members[i + 1];
            }
            members[count - 1] = null;
            count--;
            Console.WriteLine("Member deleted successfully.");
        }

        public static int FindIndexById(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (members[i].Id == id) return i;
            }
            return -1;
        }
    }
}