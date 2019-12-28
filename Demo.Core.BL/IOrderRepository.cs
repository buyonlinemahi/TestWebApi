using Demo.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BL
{
    public interface IOrderRepository
    {
        #region order
        long AddOrder(Order _order);
        long UpdateOrder(Order _order);
        void DeleteOrder(long id);
        Order GetOrderByID(long _id);
        IEnumerable<BLModel.Order> GetOrders();
        #endregion
    }
}
