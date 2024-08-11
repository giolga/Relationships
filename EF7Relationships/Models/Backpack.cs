using System.ComponentModel.DataAnnotations;

namespace EF7Relationships.Models
{
    public class BackPack
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } // 1:1 
    }
}
