namespace ASM_Auto.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        Task<int> SaveChangesAsync();
    }
}
