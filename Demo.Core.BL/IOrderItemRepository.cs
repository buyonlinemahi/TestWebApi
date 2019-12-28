using Demo.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BL
{
    public interface IOrderItemRepository
    {
        #region OrderItem
        long AddOrderItem(OrderItem _orderItem);
        long UpdateOrderItem(OrderItem _orderItem);
        void DeleteOrderItem(long id);
        OrderItem GetOrderItemByID(long _id);
        IEnumerable<BLModel.OrderItem> GetOrderItemsByOrderID(long OrderID);
        #endregion
    }
}
