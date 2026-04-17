using Practice_13.Data;
using Practice_13.Interfaces;
using Practice_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_13.Services
{
    public class PaymentService : IService<Payment>
    {
        public void Add(Payment item)
        {
            var from = Database.Accounts.FirstOrDefault(a => a.Id == item.FromAccountId);
            var to = Database.Accounts.FirstOrDefault(a => a.Id == item.ToAccountId);

            if (from == null || to == null) throw new Exception("Account not found.");
            if (from.Currency != to.Currency) throw new Exception("Currency mismatch.");
            if (from.Balance < item.Amount) throw new Exception("Insufficient balance.");

            from.Balance -= item.Amount;
            to.Balance += item.Amount;
            Database.Payments.Add(item);
        }

        public List<Payment> GetAll() => Database.Payments;
        public Payment GetById(Guid id) => Database.Payments.FirstOrDefault(p => p.Id == id);
        public void Update(Payment item) { }
        public void Delete(Payment item) => Database.Payments.Remove(item);

        // Function bolo n transactions sanaxavad
        public List<Payment> GetHistory(Guid clientId, int n)
        {
            var accountIds = Database.Accounts
                .Where(a => a.ClientId == clientId)
                .Select(a => a.Id);

            return Database.Payments
                .Where(p => accountIds.Contains(p.FromAccountId) || accountIds.Contains(p.ToAccountId))
                .OrderByDescending(p => p.CreatedOn)
                .Take(n)
                .ToList();
        }
    }
}