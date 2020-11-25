using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
    }
}
