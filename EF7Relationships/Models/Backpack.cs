using System.Text.Json.Serialization;

namespace EF7Relationships.Models
{
    public class Backpack
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; } //characters and backpacks are 1:1 relationships, so we need in both classes id of character/backpack and that class
        [JsonIgnore]
        public Character Character { get; set; }
    }
}
