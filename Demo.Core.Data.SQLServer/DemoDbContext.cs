using Microsoft.EntityFrameworkCore;
using Demo.Core.Data.Model;
using BLModel =Demo.Core.BLModel;
using BLBase = Demo.Core.BLModel.Base;

namespace Demo.Core.Data.SQLServer
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }
        #region TotalCount
        public virtual DbSet<BLBase.BasePaged> BasePaged { get; set; }
        #endregion
        #region PaymentDetail
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        #endregion
        #region User
        public virtual DbSet<User> Users { get; set; }
        #endregion
        #region Customer
        public virtual DbSet<Customer> Customers { get; set; }
        #endregion
        #region Item
        public virtual DbSet<Item> Items { get; set; }
        #endregion
        #region OrderItem
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<BLModel.OrderItem> BLOrderItems { get; set; }
        #endregion
        #region Order
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<BLModel.Order> BLOrders { get; set; }
       
        #endregion
    }
}
