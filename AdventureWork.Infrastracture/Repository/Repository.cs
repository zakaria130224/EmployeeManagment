using AdventureWork.Core.Repository;
using AdventureWork.Infrastracture.DBContext;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AdventureWork.Infrastracture.Repository
{
    public class Repository<TEntity> : DbContext,IRepository<TEntity> where TEntity : class
    {
      
        internal DatabaseContext context;
        internal DbSet<TEntity> dbSet;

        public Repository()
        {
            context=new DatabaseContext();
            dbSet = context.Set<TEntity>();
        }

        public void Delete(long id, bool persist = false)
        {           
            dbSet.Remove(dbSet.Find(id));
            context.SaveChanges();
        }

        public void Delete(TEntity model, bool persist = false)
        {
            dbSet.Remove(model);

            context.SaveChanges();
        }

        public TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public bool Insert(TEntity model, bool persist = false)
        {
            dbSet.Add(model);
            context.SaveChanges();
            return true;
        }

        public bool Update(TEntity model, bool persist = false)
        {    
            /*
            *https://stackoverflow.com/questions/30987806/dbset-attachentity-vs-dbcontext-entryentity-state-entitystate-modified
            */
            //dbSet.Attach(model);
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
            
            return true;
        }
       

    }
}
