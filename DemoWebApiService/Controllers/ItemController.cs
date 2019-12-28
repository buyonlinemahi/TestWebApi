using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Demo.Core.BL;
using Demo.Core.BLImplementation;
using Demo.Core.Data.SQLServer;
using DemoService.DTO;
using System.Collections.Generic;
using DemoWebApiService.Services;
using System;

namespace DemoWebApiService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ItemController : ControllerBase
    {
        private IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemController(DemoDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _itemRepository = new ItemRepository(context);
        }

        [HttpGet("api/Item/GetItemByID/{Id}")]
        public IActionResult GetItemByID(int Id)
        {
            try
            {
                Item _item = _mapper.Map<Item>(_itemRepository.GetItemByID(Id));
                return _item == null ? NotFound(_item) : (IActionResult)Ok(_item);
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
}

        [HttpGet("api/Item/GetAllItems")]
        public IActionResult GetAllItems()
        {
            try
            {
                var _order = _mapper.Map<IEnumerable<Order>>(_itemRepository.GetItems());
                return _order == null ? NotFound(_order) : (IActionResult)Ok(_order);
            }             
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}