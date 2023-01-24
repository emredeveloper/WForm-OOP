using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using NorthWind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class  , IEntity ,new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedentity = context.Entry(entity); // veritabanında ilgili nesneye erişme
                addedentity.State = EntityState.Added; // ekleyeceğimiz için veritabanında bulamayacak yani girdiğimiz değeri yeni veri olarak kabul edecek
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteentity = context.Entry(entity);
                deleteentity.State = EntityState.Modified; 
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter==null?context.Set<TEntity>().ToList():context.Set<TEntity>().Where(filter).ToList();  
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatentity = context.Entry(entity); // veritabanında ilgili nesneye erişme
                updatentity.State = EntityState.Modified; // ekleyeceğimiz için veritabanında bulduğunda  yani girdiğimiz değeri yeni veri olarak kabul edecek ve update edecek
                context.SaveChanges();
            }
            
        }
    }
}
