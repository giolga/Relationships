using System.ComponentModel.DataAnnotations;

namespace EF7Relationships.Models
{
    public class Faction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Character> Characters{ get; set; }

    }
}
