using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        IEnumerable<MenuItem> GetAllMenuItems();
        MenuItem GetItemFromTable(int? id);
    }
}
