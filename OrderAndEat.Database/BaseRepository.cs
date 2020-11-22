using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public abstract class BaseRepository<Entity> where Entity : class
    {
        protected OrderAndEatDbContext _dbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(OrderAndEatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
            {
                list.Add(entity);
            }

            return list;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
