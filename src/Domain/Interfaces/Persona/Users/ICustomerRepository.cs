using Domain.Models.Persona.Users;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persona.Users
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByEmail(string email);
        Task<IEnumerable<Customer>> GetAll();

        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}