using EF7Relationships.Data;
using EF7Relationships.DTOs;
using EF7Relationships.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF7Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly DataContext _context;
        public RelationshipsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var character = await _context.Characters.Include(c => c.Backpack)
                                                     .Include(c => c.Weapons)
                                                     .Include(c => c.Factions)
                                                     .FirstOrDefaultAsync(c => c.Id == id);

            if(character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            var newCharacter = new Character()
            {
                Name = request.Name
            };

            var backpack = new Backpack()
            {
                Description = request.Backpack.description,
                Character = newCharacter
            };

            var weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, Character = new Character() }).ToList();
            var factions = request.Fractions.Select(f => new Faction { Name = f.Name, Characters = new List<Character> { newCharacter } }).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(c => c.Backpack).Include(c => c.Weapons).ToListAsync());
        }

    }
}
