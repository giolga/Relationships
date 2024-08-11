namespace EF7Relationships.DTOs
{
    public class CharacterDto
    {
        public string Name { get; set; }
        public BackpackDto Backpack { get; set; }
        public IEnumerable<WeaponDto> Weapons { get; set; }
        public IEnumerable<FactionDto> Factions { get; set; }
    }
}
