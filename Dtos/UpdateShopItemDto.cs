using System.ComponentModel.DataAnnotations;
namespace RPGShop.Dtos
{
    public record UpdateShopItemDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 9999)]
        public int Price { get; init; }
        [Required]
        public string Type { get; init; }
        [Required]
        public string Rarity { get; init; }
    }
}