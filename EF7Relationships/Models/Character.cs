namespace EF7Relationships.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int BackpackId { get; set; }
        public Backpack Backpack { get; set; }
        public List<Weapon> Weapons { get; set; } // One character can have many weapons 1:n
        public List<Faction> Factions { get; set; } // n:n
    }
}
