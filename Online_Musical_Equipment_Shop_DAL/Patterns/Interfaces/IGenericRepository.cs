using Online_Musical_Equipment_Shop_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Patterns.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllEntitiesAsync();

        Task<TEntity> GetEntityByIdAsync(Guid Id);

        Task<TEntity> InsertEntityAsync(TEntity entity);

        Task<TEntity> UpdateEntityAsync(TEntity entity);

        Task<IEnumerable<TEntity>> DeleteEntityByIdAsync(Guid Id);
    }
}
