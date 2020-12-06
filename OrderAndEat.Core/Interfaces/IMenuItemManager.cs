using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public interface IMenuItemManager
    {
        IEnumerable<MenuItemDto> GetAllMenuItems();
        bool AddNewMenuItem(MenuItemDto menuItemDto);
        bool EditMenuItem(MenuItemDto menuItemDto);
        MenuItemDto GetMenuItem(int? id);
    }
}
