﻿using EF7Relationships.Models;
using Microsoft.EntityFrameworkCore;

namespace EF7Relationships.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<BackPack> BackPacks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Faction> Factions { get; set; }

    }
}
