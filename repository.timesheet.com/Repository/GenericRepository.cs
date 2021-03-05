using db.timesheet.com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace repository.timesheet.com {
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class {

        protected readonly TimeSheetDBContext context;

        public GenericRepository(TimeSheetDBContext _context) {
            context = _context;
        }

        public void Add(TEntity entity) {
            context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entity) {
            context.Set<TEntity>().AddRange(entity);
        }

        public TEntity Get(Guid ID) {
            return context.Set<TEntity>().Find(ID);
        }

        public IEnumerable<TEntity> GetAll() {
          return  context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity) {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entity) {
            context.Set<TEntity>().RemoveRange(entity);
        }

        public void Update(TEntity entity, TEntity newValues) {
            
        }
    }
}
