using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Common.Repositories
{
    public interface ICRUDRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        public IEnumerable<TEntity> Get();
        public TEntity Get(TId id);
        public TId Create(TEntity entity);
        public void Update(TId id, TEntity entity);
        public void Delete(TId id);
    }
}
