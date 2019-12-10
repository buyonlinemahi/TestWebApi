using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using System.Collections.Generic;
using Xunit;

namespace Demo.UnitTest
{
    public class PaymentDetailTest
    {
        IPaymentDetailRepository _paymentDetailRepository;
        readonly DemoDbContext _context;

        public PaymentDetailTest()
        {
            var builder = new DbConnection();
            _context = new DemoDbContext((builder.InitConfiguration()).Options);
            _paymentDetailRepository = new PaymentDetailRepository(_context);
        }

        #region Users
        [Fact]
        public void AddPayment()
        {
            PaymentDetail _payment = new PaymentDetail
            {
                CardOwnerName = "TestDheeraj",
                CardNumber = "1701002687431245",
                ExpirationDate = "09/12/2019",
                CVV = "111"

            };
            var id = _paymentDetailRepository.AddPaymentDetail(_payment);
            Assert.True(id > 0, "failed");

        }
        [Theory]
        [InlineData(1)]
        public void GetUserByID(int ID)
        {
            var userByName = _paymentDetailRepository.GetPaymentDetailByID(ID);
            Assert.True(userByName != null, "failed");
        }

        [Fact]
        public void getAllCategory()
        {
            IEnumerable<PaymentDetail> categories = _paymentDetailRepository.getAllPaymentDetail();
            Assert.True(categories != null, "failed");
        }
        #endregion
    }
}
