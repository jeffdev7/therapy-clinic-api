using clinic.data.DBConfiguration;
using clinic.data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinic.data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
            SaveChanges();
        }

        public bool Any(Func<TEntity, bool> exp)
        {
            return _dbSet.Any(exp);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp)
        {
            return _dbSet.Where(exp).AsQueryable();
        }

        public TEntity GetBy(Func<TEntity, bool> exp)
        {
            return _dbSet.FirstOrDefault(exp);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
            SaveChanges();
        }
    }
}