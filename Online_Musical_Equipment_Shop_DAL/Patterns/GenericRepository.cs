using Microsoft.EntityFrameworkCore;
using Online_Musical_Equipment_Shop_DAL.Context;
using Online_Musical_Equipment_Shop_DAL.Entities;
using Online_Musical_Equipment_Shop_DAL.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Patterns
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly MusicalEquipmentShopContext _context;

        private readonly DbSet<TEntity> _set;

        public GenericRepository(MusicalEquipmentShopContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetEntityByIdAsync(Guid Id)
        {
            var entity = await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);

            if (entity == null) 
            {
                throw new Exception("The entity is null!!!");
            }

            return entity;
        }

        public async Task<TEntity> InsertEntityAsync(TEntity entity)
        {
            await _set.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            var result = await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (result == null)
            {
                throw new NullReferenceException($"The informations with {entity.Id} ID not found!!!");
            }

            _set.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> DeleteEntityByIdAsync(Guid Id)
        {
            var entity = await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);

            if (entity == null)
            {
                throw new NullReferenceException($"The informations with {Id} ID not found!!!");
            }

            _set.Remove(entity);

            await _context.SaveChangesAsync();

            return await _set.AsNoTracking().ToListAsync();
        }
    }
}
