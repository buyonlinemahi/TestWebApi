using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.SQLServer;
using DemoService.DTO;
using System.Collections.Generic;
using DemoWebApiService.Services;
using System;
using System.Linq;

namespace DemoWebApiService.Controllers
{
   
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;
        public OrderController(DemoDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = new OrderRepository(context);
            _orderItemRepository = new OrderItemRepository(context);
        }
        [HttpPost("api/Order/PostOrder/{_order}")]
        public ActionResult PostOrder(Order _order)
        {
            try
            { 
            //Order table
            if (_order.OrderID ==0)
                _orderRepository.AddOrder(_mapper.Map<Demo.Core.Data.Model.Order>(_order));
            else
                _orderRepository.UpdateOrder(_mapper.Map<Demo.Core.Data.Model.Order>(_order));

            //OrderItems table
            foreach (var item in _order.OrderItems)
            {
                if (item.OrderItemID == 0)
                    _orderItemRepository.AddOrderItem(_mapper.Map<Demo.Core.Data.Model.OrderItem>(item));
                else
                    _orderItemRepository.UpdateOrderItem(_mapper.Map<Demo.Core.Data.Model.OrderItem>(item));
            }
                // Delete for OrderItems
                foreach (var id in _order.DeletedOrderItemIDs.Split(',').Where(x => x != ""))
                {
                    _orderItemRepository.DeleteOrderItem(Convert.ToInt64(id));
                }
               
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/Order/5
        [HttpPost("api/Order/DeleteOrder/{id}")]
        public IActionResult DeleteOrder(long id)
        {
            var _orderItems = _mapper.Map<IEnumerable<OrderItem>>(_orderItemRepository.GetOrderItemsByOrderID(id));
            foreach (var item in _orderItems.ToList())
            {
                _orderItemRepository.DeleteOrderItem(item.OrderItemID);
            }
            _orderRepository.DeleteOrder(id);
            return Ok();
        }

        [HttpGet("api/Order/GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var _order = _mapper.Map<IEnumerable<Order>>(_orderRepository.GetOrders());
                return _order == null ? NotFound(_order) : (IActionResult)Ok(_order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
}
        [HttpGet("api/Order/GetOrders/{Id}")]
        public IActionResult GetOrderAndOrderItem(long id)
        {
            try
            {
                var _order = _mapper.Map<Order>(_orderRepository.GetOrderByID(id));
                var _orderItems = _mapper.Map<IEnumerable<OrderItem>>(_orderItemRepository.GetOrderItemsByOrderID(id));
                return Ok(new { _order, _orderItems });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}