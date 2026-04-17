using System;

namespace Practice_13.Models
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}