using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ASMAutoDbContext _dbContext;

        public Repository(ASMAutoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.DbSet = this._dbContext.Set<TEntity>();
        }

        public DbSet<TEntity> DbSet { get; set; }

        public async Task AddAsync(TEntity entity)
                 => await this.DbSet.AddAsync(entity).AsTask();

        public void Delete(TEntity entity)
               => this.DbSet.Remove(entity);

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return this.DbSet;
        }

        public Task<int> SaveChangesAsync()
                   => _dbContext.SaveChangesAsync();

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {
                this._dbContext?.Dispose();
            }

        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
