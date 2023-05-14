namespace clinic.data.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp);
        TEntity GetBy(Func<TEntity, bool> exp);
        bool Any(Func<TEntity, bool> exp);
        void Update(TEntity obj);
        void Remove(int id);
        int SaveChanges();
    }
}