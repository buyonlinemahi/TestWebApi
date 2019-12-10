using Microsoft.EntityFrameworkCore;
using Demo.Core.Data.Model;

namespace Demo.Core.Data.SQLServer
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }
        #region PaymentDetail
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        #endregion
    }
}
