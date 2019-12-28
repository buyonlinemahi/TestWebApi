using Demo.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BL
{
    public interface IItemRepository
    {
        #region Item
        int AddItem(Item _customer);
        int UpdateItem(Item _item);
        void DeleteItem(int id);
        Item GetItemByID(int _id);
        IEnumerable<Item> GetItems();
        #endregion
    }
}
