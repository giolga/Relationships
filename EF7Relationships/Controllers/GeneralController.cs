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

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Characters.
                Include(c => c.BackPack).
                Include(c => c.Weapons).
                Include(c => c.Factions).
                FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
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
            var factions = request.Factions.Select(f => new Faction() { Name = f.Name, Characters = new List<Character> { newCharacter } }).ToList();

            newCharacter.BackPack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(c => c.BackPack).Include(c => c.Weapons).ToListAsync());

        }
    }
}
