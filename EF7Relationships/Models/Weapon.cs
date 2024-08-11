using System.ComponentModel.DataAnnotations;

namespace EF7Relationships.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
