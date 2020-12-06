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

        public bool AddNewMenuItem(MenuItemDto menuItemDto)
        {
            var entity = _dtoMapper.Map(menuItemDto);

            return _menuItemRepository.AddNew(entity);
        }

        public MenuItemDto GetMenuItem(int? id)
        {
            var menuItemEntity = _menuItemRepository.GetItemFromTable(id);
            return _dtoMapper.Map(menuItemEntity);
        }



    }

}
