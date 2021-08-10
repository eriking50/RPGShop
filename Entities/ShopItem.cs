using System;

namespace RPGShop.Entities
{
    public record ShopItem
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public string Type { get; init; }
        public string Rarity { get; init; }
    }
}