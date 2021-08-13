using Microsoft.AspNetCore.Mvc;
using RPGShop.Entities;
using RPGShop.Repositories;
using System;
using System.Linq;
using RPGShop.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<ShopItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
            return items;
        }
        // GET /items/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        // GET /items/t/type
        [HttpGet("t/{type}")]
        public async Task<IEnumerable<ShopItemDto>> GetItemsByTypeAsync(string type)
        {
            var items = (await repository.GetItemByTypeAsync(type)).Select(item => item.AsDto());
            return items;
        }
        // GET /items/r/rarity
        [HttpGet("r/{rarity}")]
        public async Task<IEnumerable<ShopItemDto>> GetItemsByRarityAsync(string rarity)
        {
            var items = (await repository.GetItemRarityAsync(rarity)).Select(item => item.AsDto());
            return items;
        }
        // POST /items
        [HttpPost]
        public async Task<ActionResult<ShopItemDto>> CreateShopItemAsync(CreateShopItemDto i)
        {
            ShopItem item = new()
            {
                Id = Guid.NewGuid(),
                Name = i.Name,
                Price = i.Price,
                Type = i.Type,
                Rarity = i.Rarity
            };
            await repository.CreateShopItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
        }
        // PUT /items/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShopItemAsync(Guid id, UpdateShopItemDto i)
        {
            var item = await repository.GetItemAsync(id);
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
            await repository.UpdateShopItemAsync(UpdItem);

            return NoContent();
        }
        // DELETE /items/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShopItemAsync(Guid id)
        {
            var item = repository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            await repository.DeleteShopItemAsync(id);

            return NoContent();
        }
    }
}