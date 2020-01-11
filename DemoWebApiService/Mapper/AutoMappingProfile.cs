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

            CreateMap<Order, Core.Order>();
            CreateMap<Core.Order, Order>();
            #endregion

            #region Item
            CreateMap<Item,Core.Item>();
            CreateMap<Core.Item, Item>();
            #endregion

            #region Customer
            CreateMap<Customer, Core.Customer>();
            CreateMap<Core.Customer, Customer>();
            #endregion

            #region OrderItem
            CreateMap<OrderItem, Core.OrderItem>();
            CreateMap<Core.OrderItem, OrderItem>();

            CreateMap<OrderItem, BLCore.OrderItem>();
            CreateMap<BLCore.OrderItem, OrderItem>();
            #endregion
        }
    }
}
