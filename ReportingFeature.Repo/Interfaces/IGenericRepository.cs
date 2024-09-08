using System.Linq.Expressions;

namespace ReportingFeature.REPO.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllAsNoTracking();
        TEntity GetSingle(Expression<Func<TEntity, bool>> expression);
        TEntity GetSingleAsNoTracking(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAsNotracking(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetAsNotracking2(Expression<Func<TEntity, bool>> expression);
        TEntity GetById(Guid? id);
        int Count(Expression<Func<TEntity, bool>> expression);
        void Insert(TEntity entity);
        void Delete(string id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void Change(TEntity entityToUpdate);
        TEntity Find(Expression<Func<TEntity, bool>> match, string[] includes = null);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match, string[] includes = null);

    }
}
