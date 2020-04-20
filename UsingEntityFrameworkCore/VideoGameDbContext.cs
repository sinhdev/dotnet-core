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

        public bool initDatabase()
        {
            // The line below clears and resets the databse.
            bool deleted = this.Database.EnsureDeleted();
            // Create the database if it does not exist
            bool created = this.Database.EnsureCreated();
            return deleted && created;
        }
    }
}