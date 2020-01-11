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
        [HttpPost("api/Order/PostOrder/{orderParam}")]
        public ActionResult PostOrder(Order orderParam)
        {
            try
            {
                //Order table
                if (orderParam.OrderID == 0)
                {
                    orderParam.OrderID = _orderRepository.AddOrder(_mapper.Map<Demo.Core.Data.Model.Order>(orderParam));
                }
                else
                {
                     _orderRepository.UpdateOrder(_mapper.Map<Demo.Core.Data.Model.Order>(orderParam));
                }

                //OrderItems table
                foreach (var item in orderParam.OrderItems)
                {
                    if (item.OrderItemID == 0)
                    {
                        item.OrderID = orderParam.OrderID;
                        _orderItemRepository.AddOrderItem(_mapper.Map<Demo.Core.Data.Model.OrderItem>(item));
                    }
                    else
                    {
                        item.OrderID = orderParam.OrderID;
                        _orderItemRepository.UpdateOrderItem(_mapper.Map<Demo.Core.Data.Model.OrderItem>(item));
                    }
                }
                // Delete for OrderItems
                if (orderParam.DeletedOrderItemIDs != null && orderParam.DeletedOrderItemIDs != "")
                {
                    foreach (var id in orderParam.DeletedOrderItemIDs.Split(',').Where(x => x != ""))
                    {
                        _orderItemRepository.DeleteOrderItem(Convert.ToInt64(id));
                    }
                }
               
                return Ok(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/Order/5
        [HttpDelete("api/Order/DeleteOrder/{id}")]
        public IActionResult DeleteOrder(long id)
        {
            try
            {
                var _orderItems = _mapper.Map<IEnumerable<OrderItem>>(_orderItemRepository.GetOrderItemsByOrderID(id));
                foreach (var item in _orderItems.ToList())
                {
                    _orderItemRepository.DeleteOrderItem(item.OrderItemID);
                }
                _orderRepository.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("api/Order/GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                OrderList obj = new OrderList();
                var _order = _orderRepository.GetOrders();
                 obj.OrderLists = _mapper.Map<IEnumerable<Order>>(_order);
                obj.TotalCount = _order.Count();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("api/Order/GetOrderAndOrderItem/{Id}")]
        public IActionResult GetOrderAndOrderItem(long id)
        {
            try
            {

                Order _order = _mapper.Map<Order>(_orderRepository.GetOrderByID(id));
                _order.OrderItems = _mapper.Map<IEnumerable<OrderItem>>(_orderItemRepository.GetOrderItemsByOrderID(id));
                return Ok(_order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}