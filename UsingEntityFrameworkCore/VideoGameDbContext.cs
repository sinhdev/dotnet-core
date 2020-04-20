using Microsoft.EntityFrameworkCore;
namespace UsingEntityFrameworkCore
{
    public class VideoGameDbContext : DbContext
    {
        public DbSet<VideoGame> VideoGames { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./VideoGame.db");
        }
    }
}