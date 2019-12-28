using Demo.Core.BL;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using BLModel = Demo.Core.BLModel;

namespace Demo.Core.BLImplementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BaseRepository<Order> _ordersRepository;
        private readonly DemoDbContext _dbContext;
        public OrderRepository(DemoDbContext DbContext)
        {
            _ordersRepository = new BaseRepository<Order>(DbContext);
            _dbContext = DbContext;
        }
        #region Order
        public long AddOrder(Order _order)
        {
            return _ordersRepository.Add(_order).OrderID;
        }

        public long UpdateOrder(Order _order)
        {
            return _ordersRepository.Update(_order);
        }

        public void DeleteOrder(long id)
        {
            _ordersRepository.Delete(id);
        }

        public Order GetOrderByID(long _id)
        {
            return _ordersRepository.GetById(_id);
        }
        public IEnumerable<BLModel.Order> GetOrders()
        {
            return _dbContext.BLOrders.FromSql($"GET_OrderAll");
            
        }
        #endregion
    }
}
