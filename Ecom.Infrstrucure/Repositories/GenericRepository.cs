using Ecom.Core.Interface;
using Ecom.Infrstrucure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrstrucure.Repositories
{
    public class GenericRepository<T> : IGenreicRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T entitie)
        {
            await _dbContext.Set<T>().AddAsync(entitie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(Id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var item in include) 
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var item in include)
            {
                query = query.Include(item);
            }
            var entity = await query.FirstOrDefaultAsync(x=>EF.Property<int>(x,"Id")==id);
            return entity;
        }

        public async Task UpdateAsync(T entitie)
        {
            _dbContext.Entry(entitie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
