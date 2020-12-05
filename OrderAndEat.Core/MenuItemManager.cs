using OrderAndEat.Database;
using System.Collections.Generic;

namespace OrderAndEat.Core
{

    public class MenuItemManager : IMenuItemManager
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly DtoMapper _dtoMapper;

        public MenuItemManager(IMenuItemRepository menuItemRepository,
                               DtoMapper dtoMapper)
        {
            _menuItemRepository = menuItemRepository;
            _dtoMapper = dtoMapper;
        }

        public IEnumerable<MenuItemDto> GetAllMenuItems()
        {
            var menuItemsEntities = _menuItemRepository.GetAllMenuItems();
            return _dtoMapper.Map(menuItemsEntities);
        }

        

    }

}
