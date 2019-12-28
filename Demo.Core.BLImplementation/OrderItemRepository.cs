using Demo.Core.BL;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BLImplementation
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly BaseRepository<OrderItem> _orderItemRepository;
        private readonly DemoDbContext _dbContext;
        public OrderItemRepository(DemoDbContext DbContext)
        {
            _orderItemRepository = new BaseRepository<OrderItem>(DbContext);
            _dbContext = DbContext;
        }
        #region OrderItem
        public long AddOrderItem(OrderItem _orderItem)
        {
            return _orderItemRepository.Add(_orderItem).OrderItemID;
        }

        public long UpdateOrderItem(OrderItem _orderItem)
        {
            return _orderItemRepository.Update(_orderItem);
        }

        public void DeleteOrderItem(long id)
        {
            _orderItemRepository.Delete(id);
        }

        public OrderItem GetOrderItemByID(long _id)
        {
            return _orderItemRepository.GetById(_id);
        }

        public IEnumerable<BLModel.OrderItem> GetOrderItemsByOrderID(long OrderID)
        {
            return _dbContext.BLOrderItems.FromSql($"GET_OrderItemByOrderId {OrderID}");
        }
        #endregion
    }
}
