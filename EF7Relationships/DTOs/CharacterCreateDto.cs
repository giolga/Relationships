using EF7Relationships.Models;

namespace EF7Relationships.DTOs
{
    public record struct CharacterCreateDto(string Name, 
                                            BackpackCreateDto Backpack, 
                                            List<WeaponCreateDto> Weapons,
                                            List<FactionCreateDto> Fractions);
}
    