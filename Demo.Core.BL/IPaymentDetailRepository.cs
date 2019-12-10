using Demo.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.BL
{
    public interface IPaymentDetailRepository
    {
        #region PaymentDetails
        int AddPaymentDetail(PaymentDetail _PaymentDetails);
        int UpdatePaymentDetail(PaymentDetail _PaymentDetails);
        void DeletePaymentDetail(int id);
        PaymentDetail GetPaymentDetailByID(int _id);
        void updatePasswordByID(int PaymentDetailID, string Password);
        IEnumerable<PaymentDetail> getAllPaymentDetail();
        #endregion
    }
}
