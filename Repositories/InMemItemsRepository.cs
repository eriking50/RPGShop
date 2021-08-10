using RPGShop.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
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

        public IEnumerable<ShopItem> GetItems()
        {
            return Items;
        }
        public ShopItem GetItem(Guid id)
        {
            return Items.Where(item => id == item.Id).SingleOrDefault();
        }
        public IEnumerable<ShopItem> GetItemByType(string type)
        {
            return Items.Where(item => type == item.Type);
        }
        public IEnumerable<ShopItem> GetItemRarity(string rarity)
        {
            return Items.Where(item => rarity == item.Rarity);
        }
        public void CreateShopItem(ShopItem item)
        {
            Items.Add(item);
        }
        public void UpdateShopItem(ShopItem item)
        {
            var index = Items.FindIndex(i => i.Id == item.Id);
            Items[index] = item;
        }
        public void DeleteShopItem(Guid id)
        {
            var index = Items.FindIndex(i => i.Id == id);
            Items.RemoveAt(index);
        }
    }
}