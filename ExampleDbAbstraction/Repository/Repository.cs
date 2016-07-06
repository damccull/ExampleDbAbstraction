using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        //The generic allows this repository class to be a common ancestor for any
        //type in the database and this class should ONLY contain methods common to every type in the database.


        //This Context property will hold whatever your database object is. In this example it's
        //just a List<TEntity> but for Entity Framework it would be a DbContext. Whatever the database
        //object is for MySql would go here.
        protected readonly List<TEntity> Context;

        public Repository(List<TEntity> context) {
            //When constructing this repository (or derived classes) you would inject the data store object.
            this.Context = context;
        }

        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void Add(TEntity entity) {
            Context.Add(entity);
        }

        /// <summary>
        /// Adds a bunch of entities to the data store.
        /// </summary>
        /// <param name="entities">An IEnumerable of the entities to add.</param>
        public void AddRange(IEnumerable<TEntity> entities) {
            Context.AddRange(entities);
        }

        /// <summary>
        /// Return all entities that match the predicate.
        /// </summary>
        /// <param name="predicate">The LINQ query to filter on.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) {
            return Context.Where(predicate);
        }

        /// <summary>
        /// Return a specific entity by ID, if the entity type has an ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id) {
            return Context.Find(e=> {
                var property = e.GetType().GetProperty("Id");
                if(property == null) {
                    throw new Exception($"No such property exists on type {e.GetType().FullName}.");
                }
                if((int)property.GetValue(e) == id) {
                    return true;
                }
                return false;
            });
        }

        /// <summary>
        /// Get all of the entities in the data store.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll() {
            return Context.ToList();
        }

        /// <summary>
        /// Remove an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        public void Remove(TEntity entity) {
            Context.Remove(entity);
        }

        /// <summary>
        /// Remove a bunch of entities.
        /// </summary>
        /// <param name="entities">The IEnumerable of all the entities to remove.</param>
        public void RemoveRange(IEnumerable<TEntity> entities) {
            foreach (var e in entities) {
                Context.Remove(e);
            }
        }
    }
}
