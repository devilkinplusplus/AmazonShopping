using AmazonShopping.Core.Entity;
using AmazonShopping.Core.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonShopping.Core.DataAcces.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
                where TEntity : class, IEntity
                where TContext : IdentityDbContext<User>, new()
    {
        public void Add(TEntity entity)
        {
            using var context = new TContext();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            return filter==null?
                   context.Set<TEntity>().ToList():
                   context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
