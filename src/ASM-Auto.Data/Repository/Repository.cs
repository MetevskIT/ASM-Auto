using Microsoft.EntityFrameworkCore;

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

        public void DeleteRange(List<TEntity> entities)
               => this.DbSet.RemoveRange(entities);

        public IQueryable<TEntity> GetAll()
               => this.DbSet;

        public Task<int> SaveChangesAsync()
               => _dbContext.SaveChangesAsync();

        public void Update(TEntity entity)
               => this.DbSet.Update(entity);

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
