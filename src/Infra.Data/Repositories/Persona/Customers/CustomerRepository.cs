using Domain.Interfaces.Persona.Users;
using Domain.Models.Persona.Users;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace Infra.Data.Repositories.Persona.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly BaseDbContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(BaseDbContext context)
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Customer> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            DbSet.Add(customer);
        }

        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
