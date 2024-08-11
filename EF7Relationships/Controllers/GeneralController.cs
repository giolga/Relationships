using EF7Relationships.Data;
using EF7Relationships.DTOs;
using EF7Relationships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF7Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly DataContext _context;
        public GeneralController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Character>>> CreateCharacter(CharacterDto request)
        {
            var newCharacter = new Character()
            {
                Name = request.Name,
            };

            var backpack = new BackPack() { Description = request.Backpack.Description, Character = newCharacter };
            var weapons = request.Weapons.Select(w => new Weapon() { Name = w.Name, Character = newCharacter }).ToList();
            var factions = request.Factions.Select(f => new Faction() { Name = f.Name}).ToList();

            newCharacter.BackPack = backpack;
            newCharacter.Weapon = weapons;
            newCharacter.Factions = factions;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(c => c.BackPack).Include(c => c.Weapon).ToListAsync());

        }
    }
}
