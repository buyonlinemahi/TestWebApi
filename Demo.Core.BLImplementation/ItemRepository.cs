using Demo.Core.BL;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Core.BLImplementation
{
    public class ItemRepository : IItemRepository
    {
        private readonly BaseRepository<Item> _itemRepository;
        private readonly DemoDbContext _dbContext;
        public ItemRepository(DemoDbContext DbContext)
        {
            _itemRepository = new BaseRepository<Item>(DbContext);
            _dbContext = DbContext;
        }
        #region Item
        public int AddItem(Item _item)
        {
            return _itemRepository.Add(_item).ItemID;
        }

        public int UpdateItem(Item _item)
        {
            return _itemRepository.Update(_item);
        }

        public void DeleteItem(int id)
        {
            _itemRepository.Delete(id);
        }

        public Item GetItemByID(int _id)
        {
            return _itemRepository.GetById(_id);
        }
        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll().Select(mahi => new Item().InjectFrom(mahi)).Cast<Item>().OrderBy(mahi => mahi.ItemID).ToList();
        }
        #endregion
    }
}
