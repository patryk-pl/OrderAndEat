using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public abstract class BaseRepository<Entity> where Entity : BaseEntity
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

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
