using ReportingFeature.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace ReportingFeature.REPO
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal RFContext _dbContext;
        internal DbSet<TEntity> dbSet;


        public GenericRepository(RFContext dbContext)
        {
            this._dbContext = dbContext;
          
            this.dbSet = _dbContext.Set<TEntity>();

        }

        public virtual IQueryable<TEntity> GetAll()
        {

            return dbSet;
        }
        public virtual IQueryable<TEntity> PaginationAll(int PageSize = 100, int PageNum = 0)
        {

            return dbSet.Skip((PageNum - 1) * PageSize).Take(PageSize);
        }
        public virtual IQueryable<TEntity> GetAllAsNoTracking()
        {

            return dbSet.AsNoTracking();
        }

        public virtual IQueryable<TEntity> GetAllAsNoTrackingPagination(int PageSize = 1000, int SkipCount = 0)
        {

            //return dbSet.AsNoTracking().Skip((PageNum - 1) * PageSize).Take(PageSize);
            return dbSet.AsNoTracking().Skip(SkipCount).Take(PageSize);
        }


        public virtual async Task<TEntity?> GetSingle(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }
        public virtual async Task<TEntity?> GetSingleAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public virtual IQueryable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression);
        }
        public virtual IQueryable<TEntity> GetAsQueryablePagination(Expression<Func<TEntity, bool>> expression, int PageSize = 100, int PageNum = 0)
        {

            return dbSet.Where(expression).Skip((PageNum - 1) * PageSize).Take(PageSize);
        }
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression);
        }
        public virtual IQueryable<TEntity> GetAsNotracking(Expression<Func<TEntity, bool>> expression)
        {

            return dbSet.AsQueryable().AsNoTracking().Where(expression);
        }



        public virtual async Task<TEntity?> GetById(Guid? id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.CountAsync(expression);
        }

        public virtual void Insert(TEntity entity)
        {
            //_dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbSet.AddAsync(entity);
        }



        public virtual async void Delete(string? id)
        {

            TEntity? entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }


      
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            //_dbContext.Update(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual void Change(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);

        }
        public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> match, string[]? includes = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (includes != null)
                foreach (var incluse in includes)
                {
                    query = query.Include(incluse);

                }

            return await query.FirstOrDefaultAsync(match);
        }
        public IQueryable<TEntity> Findup(string[]? includes = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (includes != null)
                foreach (var incluse in includes)
                {
                    query = query.Include(incluse);

                }

            return query;
        }
        public IQueryable<TEntity> FindAll(int PageSize = 100, int PageNum = 0, string[]? includes = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (includes != null)
                foreach (var incluse in includes)
                {
                    //_dbContext.Configuration.LazyLoadingEnabled = false;

                    query = query.Include(incluse);

                }


            return PageNum > 1 ? query.Skip((PageNum - 1) * PageSize).Take(PageSize) : query.Take(PageSize);
        }
        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> match, int PageSize = 100, int PageNum = 0, string[]? includes = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (includes != null)
                foreach (var incluse in includes)
                {
                    //_dbContext.Configuration.LazyLoadingEnabled = false;

                    query = query.Include(incluse);

                }

            return query.Skip((PageNum - 1) * PageSize).Take(PageSize);
        }
        public async Task<IQueryable<TEntity>> FindAllAsync(int PageSize = 100, int PageNum = 0, string[]? includes = null)
        {

            return await Task.Run(async () =>
            {
                var query = dbSet;
                if (includes != null)
                    foreach (var incluse in includes)
                    {


                        query = (DbSet<TEntity>)query.Include(incluse);

                    }
                return query.Skip((PageNum - 1) * PageSize).Take(PageSize);
            });
        }
        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> match, string[]? includes = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (includes != null)
                foreach (var incluse in includes)
                {


                    query = query.Include(incluse);

                }

            return query.Where(match);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)

        {

            dbSet.RemoveRange(entities);

        }
        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)

        {

            await dbSet.AddRangeAsync(entities);



            return entities;

        }
     


     
    }
}