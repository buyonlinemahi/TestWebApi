using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.SQLServer;
using DemoService.DTO;
using System.Collections.Generic;
using System;

namespace DemoWebApiService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PaymentDetailController : ControllerBase
    {
        private IPaymentDetailRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentDetailController(DemoDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _paymentRepository = new PaymentDetailRepository(context);
        }
        [HttpPost("api/PaymentDetail/AddPaymentDetail/{_paymentDetail}")]
        public ActionResult AddUser(PaymentDetail _paymentDetail)
        {
            try
            {
                int VarpaymentID = _paymentRepository.AddPaymentDetail(_mapper.Map<Demo.Core.Data.Model.PaymentDetail>(_paymentDetail));
                return VarpaymentID == 0 ? NotFound(VarpaymentID) : (ActionResult)Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("api/PaymentDetail/UpdatePaymentDetail/{_paymentDetail}")]
        public ActionResult UpdateUser(PaymentDetail _paymentDetail)
        {
            try
            {
                int VarpaymentID = _paymentRepository.UpdatePaymentDetail(_mapper.Map<Demo.Core.Data.Model.PaymentDetail>(_paymentDetail));
                return VarpaymentID == 0 ? NotFound(VarpaymentID) : (ActionResult)Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("api/PaymentDetail/DeletePaymentDetail/{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _paymentRepository.DeletePaymentDetail(id);
                return Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("api/PaymentDetail/GetPaymentDetailByID/{Id}")]
        public IActionResult GetUserByID(int Id)
        {
            try
            {
                PaymentDetail _PaymentDetail = _mapper.Map<PaymentDetail>(_paymentRepository.GetPaymentDetailByID(Id));
                return _PaymentDetail == null ? NotFound(_PaymentDetail) : (IActionResult)Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("api/PaymentDetail/getAllPaymentDetail")]
        public IEnumerable<PaymentDetail> getAllCategory()
        {
            try
            {

                return _mapper.Map<IEnumerable<PaymentDetail>>(_paymentRepository.getAllPaymentDetail());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}