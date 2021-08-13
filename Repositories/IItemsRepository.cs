using RPGShop.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGShop.Repositories
{
    public interface IItemsRepository
    {
        Task<ShopItem> GetItemAsync(Guid id);
        Task<IEnumerable<ShopItem>> GetItemByTypeAsync(string type);
        Task<IEnumerable<ShopItem>> GetItemRarityAsync(string rarity);
        Task<IEnumerable<ShopItem>> GetItemsAsync();
        Task CreateShopItemAsync(ShopItem item);
        Task UpdateShopItemAsync(ShopItem item);
        Task DeleteShopItemAsync(Guid id);
    }
}