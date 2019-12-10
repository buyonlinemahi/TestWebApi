using Demo.Core.BL;
using Demo.Core.Data.Model;
using Demo.Core.Data.SQLServer;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using System.Collections.Generic;

namespace Demo.Core.BLImplementation
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        private readonly BaseRepository<PaymentDetail> _PaymentDetailRepository;
        private readonly DemoDbContext _dbContext;
        public PaymentDetailRepository(DemoDbContext DbContext)
        {
            _PaymentDetailRepository = new BaseRepository<PaymentDetail>(DbContext);
            _dbContext = DbContext;
        }
        #region PaymentDetails
        public int AddPaymentDetail(PaymentDetail _PaymentDetails)
        {
            return _PaymentDetailRepository.Add(_PaymentDetails).PMId;
        }

        public int UpdatePaymentDetail(PaymentDetail _PaymentDetails)
        {
            return _PaymentDetailRepository.Update(_PaymentDetails);
        }

        public void DeletePaymentDetail(int id)
        {
            _PaymentDetailRepository.Delete(id);
        }

        public PaymentDetail GetPaymentDetailByID(int _id)
        {
            return _PaymentDetailRepository.GetById(_id);
        }       

        public void updatePasswordByID(int PaymentDetailID, string Password)
        {
            _dbContext.Database.ExecuteSqlCommand("Update_PasswordByID {0},{1}", PaymentDetailID, Password);
        }

        public IEnumerable<PaymentDetail> getAllPaymentDetail()
        {
            IEnumerable<PaymentDetail> categories = _PaymentDetailRepository.GetAll().Select(js => new PaymentDetail().InjectFrom(js)).Cast<PaymentDetail>().OrderBy(js => js.PMId).ToList();
            return categories;
        }
        #endregion
    }
}
