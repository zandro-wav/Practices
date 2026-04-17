using Practice_13.Models;
using System.Collections.Generic;

namespace Practice_13.Data
{
    public static class Database
    {
        public static List<Client> Clients = new List<Client>();
        public static List<Account> Accounts = new List<Account>();
        public static List<Payment> Payments = new List<Payment>();

        public static int AccountIncrement = 0;
    }
}