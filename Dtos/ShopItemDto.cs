using System;

namespace RPGShop.Dtos
{
        public record ShopItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public string Type { get; init; }
        public string Rarity { get; init; }
    }
}