using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        bool AddNew(Entity entity);
        bool Edit(Entity entity);
        bool Delete(Entity entity);
    }
}
