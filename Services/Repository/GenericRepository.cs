using Microsoft.EntityFrameworkCore;
using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AlphaContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AlphaContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            if (entity == null)
            {
                return null;
            }

            var newEntity = Activator.CreateInstance<T>();

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.CanRead && property.CanWrite)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(newEntity, value);
                }
            }

            return newEntity;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Deactivate(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                var isActiveProperty = entity.GetType().GetProperty("IsActive");
                if (isActiveProperty != null && isActiveProperty.PropertyType == typeof(bool))
                {
                    isActiveProperty.SetValue(entity, false);
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("The entity does not have an 'IsActive' property or it is not of type bool.");
                }
            }
        }

        public async Task<T> GetByField(string fieldName, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.PropertyOrField(parameter, fieldName);
            var constant = Expression.Constant(value);
            var body = Expression.Equal(member, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return await _dbSet.FirstOrDefaultAsync(lambda);
        }
    }
}
