using Practice_13.Models;
using Practice_13.Services;
using System;

namespace Practice_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientService = new ClientService();
            var accountService = new AccountService();
            var paymentService = new PaymentService();

            // Registering a client
            Console.WriteLine("--- Registering Client ---");
            var client = new Client { FirstName = "George", LastName = "Tech", PrivateNumber = "12345" };
            clientService.Add(client);

            // Displaying Client Data
            Console.WriteLine($"Client ID: {client.Id}");
            Console.WriteLine($"Name: {client.FirstName} {client.LastName}");
            Console.WriteLine($"Private Number: {client.PrivateNumber}");
            Console.WriteLine($"Created On: {client.CreatedOn}");

            // Creating an account
            Console.WriteLine("\n--- Creating Account ---");
            var account = new Account { ClientId = client.Id, Currency = "GEL", Balance = 1000 };
            accountService.Add(account);

            // Displaying Account Data
            Console.WriteLine($"Account ID: {account.Id}");
            Console.WriteLine($"Owner ID: {account.ClientId}");
            Console.WriteLine($"Account No: {account.AccountNo}");
            Console.WriteLine($"Currency: {account.Currency}");
            Console.WriteLine($"Initial Balance: {account.Balance}");
            Console.WriteLine($"Created On: {account.CreatedOn}");

            // Keep the console open
            Console.WriteLine("\nExecution finished. Press any key to exit...");
            Console.ReadKey();
        }
    }
}