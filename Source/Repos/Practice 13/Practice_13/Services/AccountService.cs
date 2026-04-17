using Practice_13.Data;
using Practice_13.Interfaces;
using Practice_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_13.Services
{
    public class AccountService : IService<Account>
    {
        public void Add(Account item)
        {
            // Increment the account number unikaluri ID-istvis
            Database.AccountIncrement++;

            string numericPart = Database.AccountIncrement.ToString().PadLeft(10, '0');
            item.AccountNo = numericPart + item.Currency;

            Database.Accounts.Add(item);
        }

        public List<Account> GetAll() => Database.Accounts;

        public Account GetById(Guid id) => Database.Accounts.FirstOrDefault(a => a.Id == id);

        public void Update(Account item) { }

        public void Delete(Account item) => Database.Accounts.Remove(item);
    }
}