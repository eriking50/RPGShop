using Microsoft.AspNetCore.Mvc;
using RPGShop.Entities;
using RPGShop.Repositories;
using System;
using System.Linq;
using RPGShop.Dtos;
using System.Collections.Generic;

namespace RPGShop.Controllers
{
    //GET /shopitems

    [ApiController]
    [Route("items")]
    public class ShopItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ShopItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }
        // GET /items
        [HttpGet]
        public IEnumerable<ShopItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }
        // GET /items/id
        [HttpGet("{id}")]
        public ActionResult<ShopItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        // GET /items/t/type
        [HttpGet("t/{type}")]
        public IEnumerable<ShopItemDto> GetItemsByType(string type)
        {
            var items = repository.GetItemByType(type).Select(item => item.AsDto());
            return items;
        }
        // GET /items/r/rarity
        [HttpGet("r/{rarity}")]
        public IEnumerable<ShopItemDto> GetItemsByRarity(string rarity)
        {
            var items = repository.GetItemRarity(rarity).Select(item => item.AsDto());
            return items;
        }
        // POST /items
        [HttpPost]
        public ActionResult<ShopItemDto> CreateShopItem(CreateShopItemDto i)
        {
            ShopItem item = new()
            {
                Id = Guid.NewGuid(),
                Name = i.Name,
                Price = i.Price,
                Type = i.Type,
                Rarity = i.Rarity
            };
            repository.CreateShopItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }
        // PUT /items/id
        [HttpPut("{id}")]
        public ActionResult UpdateShopItem(Guid id, UpdateShopItemDto i)
        {
            var item = repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            ShopItem UpdItem = item with {
                Name = i.Name,
                Price = i.Price,
                Type = i.Type,
                Rarity = i.Rarity
            };
            repository.UpdateShopItem(UpdItem);

            return NoContent();
        }
        // DELETE /items/id
        [HttpDelete("{id}")]
        public ActionResult DeleteShopItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            repository.DeleteShopItem(id);

            return NoContent();
        }
    }
}