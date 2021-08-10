using RPGShop.Dtos;
using RPGShop.Entities;
using System;
using System.Linq;


namespace RPGShop
{
    public static class Extensions
    {
        public static ShopItemDto AsDto(this ShopItem item)
        {
            return new ShopItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Type = item.Type,
                    Rarity = item.Rarity
                };
        }
    }
}