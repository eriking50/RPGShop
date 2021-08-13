using RPGShop.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGShop.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<ShopItem> Items = new()
        {
            new ShopItem {Id= Guid.NewGuid(), Name = "Potion", Price = 10, Rarity = "Common", Type = "Consumable" },
            new ShopItem {Id= Guid.NewGuid(), Name = "Sword", Price = 15, Rarity = "Common", Type = "Weapon" },
            new ShopItem {Id= Guid.NewGuid(), Name = "Helm", Price = 13, Rarity = "Common", Type = "Armor" },
            new ShopItem {Id= Guid.NewGuid(), Name = "Ring", Price = 5, Rarity = "Common", Type = "Accessory" }
        };

        public async Task<IEnumerable<ShopItem>> GetItemsAsync()
        {
            return await Task.FromResult(Items);
        }
        public async Task<ShopItem> GetItemAsync(Guid id)
        {
            var item = Items.Where(item => id == item.Id).SingleOrDefault();
            return await Task.FromResult(item);
        }
        public async Task<IEnumerable<ShopItem>> GetItemByTypeAsync(string type)
        {
            return await Task.FromResult(Items.Where(item => type == item.Type));
        }
        public async Task<IEnumerable<ShopItem>> GetItemRarityAsync(string rarity)
        {
            return await Task.FromResult(Items.Where(item => rarity == item.Rarity));
        }
        public async Task CreateShopItemAsync(ShopItem item)
        {
            Items.Add(item);
            await Task.CompletedTask;
        }
        public async Task UpdateShopItemAsync(ShopItem item)
        {
            var index = Items.FindIndex(i => i.Id == item.Id);
            Items[index] = item;
            await Task.CompletedTask;
        }
        public async Task DeleteShopItemAsync(Guid id)
        {
            var index = Items.FindIndex(i => i.Id == id);
            Items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}