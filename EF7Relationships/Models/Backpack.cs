using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EF7Relationships.Models
{
    public class BackPack
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; } // 1:1 
    }
}
