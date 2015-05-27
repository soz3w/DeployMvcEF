using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeployMvcEF.Models.Repositories
{
    public class Repository<T>:IDisposable where T: class
    {
        private bool disposed = false;
        private MusicStoreContext context = null;

        protected DbSet<T> DbSet  {get;set;}
        public Repository ()
	    {
            context=new MusicStoreContext();
            DbSet=context.Set<T>();
	    }
        public Repository (MusicStoreContext context)
	    {
            this.context=context;
	    }
        public List<T> GetAll()
        {
            return DbSet.ToList();
        }
        public T Get(int id)
        {
            return DbSet.Find(id);
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            context.Entry<T>(entity).State=EntityState.Modified;
        }
        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            if(!disposed){
                context.Dispose();
            }
        }
  

    }
}