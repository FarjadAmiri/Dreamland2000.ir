using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace WebSite.Core.Services
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includes = "", int page = 1);
        
        Task Add(TEntity entity);
        
        Task Delete(int id);
        
        Task Update(TEntity entity);
        
        Task<bool> IsExist(int id, TEntity entity);
    }


    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await _unitOfWork.Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _unitOfWork.Context.Set<TEntity>().FindAsync(id);
        }
        
        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includes = "" , int page=1)
        {
            IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual  async Task Add(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
            await _unitOfWork.CommitAsync();
            
        }

        public virtual async Task Update(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public virtual async Task Delete(int id)
        {

            var entity = await GetById(id);
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
            await _unitOfWork.CommitAsync();
        }


        public async Task<bool> IsExist(int id, TEntity entity)
        {
            if (await _unitOfWork.Context.Set<TEntity>().FindAsync(id) != null)
            {
                return true;
            }
            return false;
        }



    }
}
