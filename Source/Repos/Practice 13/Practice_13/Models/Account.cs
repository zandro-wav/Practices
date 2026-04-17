using System;

namespace Practice_13.Models
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public string AccountNo { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}