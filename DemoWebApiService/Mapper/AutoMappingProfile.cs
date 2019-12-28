using AutoMapper;
using DemoService.DTO;
using Core = Demo.Core.Data.Model;
using BLCore = Demo.Core.BLModel;

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

            #region User
            CreateMap<User, Core.User>();
            CreateMap<Core.User, User>();
            #endregion
            #region Order
            CreateMap<Order, BLCore.Order>();
            CreateMap<BLCore.Order, Order>();
            #endregion
        }
    }
}
