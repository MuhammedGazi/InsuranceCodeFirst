using InsuranceCodeFirst.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCodeFirst.DAL.Repositories.GenericRepositories
{
    public class GenericRepository<Tentity>(AppDbContext context) : IGenericRepository<Tentity> where Tentity : class
    {
        private readonly DbSet<Tentity> _table=context.Set<Tentity>();
        public async Task CreateAsync(Tentity entity)
        {
           await context.AddAsync(entity);
        }

        public void Delete(Tentity entity)
        {
            context.Remove(entity);
        }

        public async Task<List<Tentity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public IQueryable<Tentity> GetQueryable()
        {
            return _table;
        }

        public void Update(Tentity entity)
        {
            context.Update(entity);
        }
    }
}
