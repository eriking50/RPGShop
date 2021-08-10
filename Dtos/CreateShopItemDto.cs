using System.ComponentModel.DataAnnotations;
namespace RPGShop.Dtos
{
    public record CreateShopItemDto
    {
        public string Name { get; init; }
        [Range(1, 9999)]
        public int Price { get; init; }
        public string Type { get; init; }
        public string Rarity { get; init; }
    }
}