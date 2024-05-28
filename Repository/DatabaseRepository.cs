using bobsbodymetrics.Data;
using bobsbodymetrics.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace bobsbodymetrics.Repository
{
    public class DatabaseRepository<T> : IDatabaseRepository<T> where T : class
    {
        protected ApplicationDbContext _db;
        private DbSet<T> _table;

        public DatabaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = _table;
            if (includeExpressions.Any())
            {
                query = includeExpressions
                    .Aggregate(query, (current, include) => current.Include(include));
            }
            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            if (existing != null)
            {
                _table.Remove(existing);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public DbSet<T> Table => _table;
    }
}
