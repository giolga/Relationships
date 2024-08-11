using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EF7Relationships.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }
    }
}
