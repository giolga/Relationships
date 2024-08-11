using System.ComponentModel.DataAnnotations;

namespace EF7Relationships.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public int BackPackId { get; set; }
        public BackPack BackPack { get; set; }
        public List<Weapon> Weapons { get; set; }
        public IEnumerable<Faction> Factions { get; set; }
    }
}
