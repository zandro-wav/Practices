using System;

namespace Practice_13.Models
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Purpose { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}