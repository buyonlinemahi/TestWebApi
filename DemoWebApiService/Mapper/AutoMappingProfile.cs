using AutoMapper;
using DemoService.DTO;
using Core = Demo.Core.Data.Model;

namespace DemoWebApiService.Mapper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {

            #region PaymentDetail
            CreateMap<PaymentDetail, Core.PaymentDetail>();
            CreateMap<Core.PaymentDetail, PaymentDetail>();
            #endregion
        }
    }
}
