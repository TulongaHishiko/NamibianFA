using CenoredIMS.Core.Data;
using CenoredIMS.Core.Interfaces;
using CenoredIMS.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CenoredIMS.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly dContext _context;
        protected readonly DbSet<T> _entities;
        protected readonly IErrorHandler _errorHandler;

        #region Properties
        public BaseRepository(dContext context, IErrorHandler errorHandler)
        {
            _context = context;
            _entities = _context.Set<T>();
            _errorHandler = errorHandler;
        }
        #endregion

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var entities = await _entities.ToListAsync();
            return entities.Where(x => x.isDeleted == false).AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return await Task.Run(() =>
            {
                IQueryable<T> query = _entities;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.Where(x => x.isDeleted == false).AsEnumerable();

            }
            );
        }

        public virtual async Task<T> GetSingle(int id)
        {
            return await _entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Task.Run(() =>
            {
                IQueryable<T> query = _entities;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return query.Where(predicate).FirstOrDefault();
            });

        }

        public virtual async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                var entities = _entities.Where(predicate);
                return entities.Where(x => x.isDeleted == false);
            });

        }
        public virtual async Task<IEnumerable<T>> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Task.Run(() =>
            {
                IQueryable<T> query = _entities;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                var entities = query.Where(predicate).AsEnumerable();
                return entities.Where(x => x.isDeleted == false);

            });

        }

        public virtual async Task<int> Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public virtual async Task AddRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                if (entity == null) throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));
            }
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

        }
        public virtual async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));
            var oldEntity = await _context.FindAsync<T>(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Delete(int entityID)
        {
            await Task.Run(async () =>
            {
                var entity = await _context.FindAsync<T>(entityID);
                if (entity == null) throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));
                entity.isDeleted = true;
                EntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            });

        }

    }
}
