using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Inferfaces;

namespace Core.Inferfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}