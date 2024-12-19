using Microsoft.EntityFrameworkCore;
using GameProject.API.Models;

namespace GameProject.Database
{
    public class GameDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Cell> Cells { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }
    }
}
