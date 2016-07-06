using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    //This interface is the basic definition of all methods available to ALL entity types in the data store.
    //This should not contain any entity-specific code. It is generic to allow it to be used with any class.
    //Implement this interface with your database-specific code in a new class.
    public interface IRepository<TEntity> where TEntity : class {

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
