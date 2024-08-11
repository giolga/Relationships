using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EF7Relationships.Models
{
    public class Faction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<Character> Characters{ get; set; }

    }
}
