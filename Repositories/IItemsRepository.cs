using RPGShop.Entities;
using System;
using System.Collections.Generic;

namespace RPGShop.Repositories
{
    public interface IItemsRepository
    {
        ShopItem GetItem(Guid id);
        IEnumerable<ShopItem> GetItemByType(string type);
        IEnumerable<ShopItem> GetItemRarity(string rarity);
        IEnumerable<ShopItem> GetItems();
        void CreateShopItem(ShopItem item);
        void UpdateShopItem(ShopItem item);
        void DeleteShopItem(Guid id);
    }
}