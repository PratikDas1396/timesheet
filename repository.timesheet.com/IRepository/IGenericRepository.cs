using System;
using System.Collections.Generic;

namespace repository.timesheet.com {

    public interface IGenericRepository<TEntity> where TEntity : class{

        IEnumerable<TEntity> GetAll();

        TEntity Get(Guid ID);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity); 

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity, TEntity newValues);

    }

}
