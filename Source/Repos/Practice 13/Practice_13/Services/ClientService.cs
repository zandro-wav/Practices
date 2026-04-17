using Practice_13.Data;
using Practice_13.Interfaces;
using Practice_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_13.Services
{
    public class ClientService : IService<Client>
    {
        public void Add(Client item) => Database.Clients.Add(item);
        public List<Client> GetAll() => Database.Clients;
        public Client GetById(Guid id) => Database.Clients.FirstOrDefault(c => c.Id == id);
        public void Update(Client item) { }
        public void Delete(Client item) => Database.Clients.Remove(item);
    }
}