using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Auto.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        //Task<TEntity> GetByIdAsync(int id);

        Task<int> SaveChangesAsync();
    }
}
