using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bobsbodymetrics.Interfaces
{
    public interface IDatabaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        DbSet<T> Table { get; }

    }
}